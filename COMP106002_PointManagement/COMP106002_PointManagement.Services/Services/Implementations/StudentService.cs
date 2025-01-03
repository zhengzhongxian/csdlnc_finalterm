using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.CoreHeplers;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.CoreHeplers;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using DnsClient.Internal;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMongoStudentRepository _mongoStudentRepository;
        private readonly IMetadata _metadata;
        private readonly CloudinaryHelper _cloudinaryHelper;
        private readonly IHubContext<ProgressHub> _hubContext;
        private readonly ILogger<StudentService> _logger;
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IMongoStudentRepository mongoStudentRepository, 
            IMetadata metadata, CloudinaryHelper cloudinaryHelper, IHubContext<ProgressHub> hubContext, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _mongoStudentRepository = mongoStudentRepository;
            _metadata = metadata;
            _cloudinaryHelper = cloudinaryHelper;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<ServiceResponse<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            var response = new ServiceResponse<IEnumerable<StudentDTO>>();

            try
            {
                var students = await _studentRepository.GetAllStudentsAsync();
                response.Data = _mapper.Map<IEnumerable<StudentDTO>>(students);
                response.Message = "Lấy danh sách sinh viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<StudentDTO>>> GetAllStudentsByLocationAsync(int location_id)
        {
            var response = new ServiceResponse<IEnumerable<StudentDTO>>();

            try
            {
                var students = await _studentRepository.GetAllStudentsByLocationAsync(location_id);
                response.Data = _mapper.Map<IEnumerable<StudentDTO>>(students);
                response.Message = "Lấy danh sách sinh viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<StudentDTO?>> GetStudentByIdAsync(string id)
        {
            var response = new ServiceResponse<StudentDTO?>();

            try
            {
                var student = await _studentRepository.GetStudentByIdAsync(id);
                if (student == null)
                {
                    response.Success = false;
                    response.Message = "Sinh viên không tồn tại.";
                }
                else
                {
                    response.Data = _mapper.Map<StudentDTO>(student);
                    response.Message = "Lấy sinh viên thành công.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> CreateStudentAsync(StudentCU_DTO studentDto, string made_by, int location_id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                if (string.IsNullOrEmpty(studentDto.StudentName) || string.IsNullOrEmpty(studentDto.Email) || string.IsNullOrEmpty(studentDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Tên sinh viên, email và số điện thoại là các trường bắt buộc.";
                    return response;
                }

                if (await _studentRepository.IsEmailOrPhoneExistsAsync(studentDto.Email, studentDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Email hoặc số điện thoại đã tồn tại.";
                    return response;
                }

                string imageUrl = null;
                var student = _mapper.Map<Student>(studentDto);
                student.LocationId = location_id;

                student.StudentId = await _studentRepository
                    .GenerateStudentIdAsync(student.IdAcademicYear, student.IdEs, student.FacultyId, student.LocationId.Value);
                var stopwatch = new Stopwatch();

                if (studentDto.ImageFile != null && studentDto.ImageFile.Length > 0)
                {
                    stopwatch.Start();
                    LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Bắt đầu đẩy ảnh lên Cloudinary.");

                    imageUrl = await _cloudinaryHelper.UploadImageAsync(studentDto.ImageFile, student.StudentId);
                    student.Photo = imageUrl;

                    stopwatch.Stop();
                    LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Ảnh đã được đẩy lên Cloudinary thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");
                }

                student.AuditableId = Guid.NewGuid().ToString();

                var mgstudent = _mapper.Map<MgStudentDTO>(studentDto);
                mgstudent.LocationId = location_id;
                mgstudent.Photo = imageUrl;
                mgstudent.StudentId = student.StudentId;

                var auditable = new Auditable
                {
                    auditable_id = student.AuditableId,
                    created_at = DateTime.UtcNow,
                    created_by = made_by,
                    status = 1
                };

                stopwatch.Restart();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Bắt đầu thêm sinh viên vào SQL.");

                await _studentRepository.CreateStudentAsync(student);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Sinh viên đã được thêm vào SQL thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                stopwatch.Restart();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Bắt đầu thêm sinh viên vào MongoDB.");

                await _mongoStudentRepository.AddStudentAsync(mgstudent);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Sinh viên đã được thêm vào MongoDB thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                stopwatch.Restart();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Bắt đầu thêm metadata vào Meta.");

                await _metadata.AddMetadaAsync(auditable);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.Cyan, $"[{GetVietnamTime()}] Metadata đã được thêm vào Meta thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                response.Data = true;
                response.Message = "Sinh viên đã được tạo thành công.";
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {innerException}";
                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Lỗi DbUpdateException: {innerException}");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Lỗi tổng quát: {ex.Message}");
            }

            return response;
        }

        // Hàm ghi log với màu sắc
        private void LogWithColor(ConsoleColor color, string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo chữ UTF-8
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        // Hàm lấy thời gian theo múi giờ Việt Nam
        private string GetVietnamTime()
        {
            return DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public async Task<ServiceResponse<bool>> CreateStudentinSqlAsync(StudentCU_DTO studentDto, string made_by, int location_id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                //await _hubContext.Clients.Client(connectionId).SendAsync("UpdateProgress", 10, "Bắt đầu xử lý...");
                if (string.IsNullOrEmpty(studentDto.StudentName) || string.IsNullOrEmpty(studentDto.Email) || string.IsNullOrEmpty(studentDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Tên sinh viên, email và số điện thoại là các trường bắt buộc.";
                    return response;
                }

                if (await _studentRepository.IsEmailOrPhoneExistsAsync(studentDto.Email, studentDto.PhoneNumber))
                {
                    response.Success = false;
                    response.Message = "Email hoặc số điện thoại đã tồn tại.";
                    return response;
                }
                string imageUrl = null;
                var student = _mapper.Map<Student>(studentDto);
                student.LocationId = location_id;
                if (studentDto.ImageFile != null && studentDto.ImageFile.Length > 0)
                {

                    imageUrl = await _cloudinaryHelper.UploadImageAsync(studentDto.ImageFile, student.StudentId);
                    student.Photo = imageUrl;
                }
                student.AuditableId = Guid.NewGuid().ToString();
                student.StudentId = await _studentRepository
                    .GenerateStudentIdAsync(student.IdAcademicYear, student.IdEs, student.FacultyId, student.LocationId.Value);

                await _studentRepository.CreateStudentAsync(student);
                response.Data = true;
                response.Message = "Sinh viên đã được tạo thành công.";
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {innerException}";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateStudentAsync(string made_by, string id, StudentUpdateDTO studentDto)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var existingStudent = await _studentRepository.GetStudentByIdAsync(id);
                if (existingStudent == null)
                {
                    response.Success = false;
                    response.Message = "Sinh viên không tồn tại.";
                    return response;
                }

                if (await _studentRepository.IsEmailOrPhoneExistsAsync(studentDto.Email, studentDto.PhoneNumber, id))
                {
                    response.Success = false;
                    response.Message = "Email hoặc số điện thoại đã tồn tại.";
                    return response;
                }

                string imageUrl = null;
                var stopwatch = new Stopwatch();

                if (studentDto.ImageFile != null && studentDto.ImageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingStudent.Photo))
                    {
                        stopwatch.Start();
                        LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Bắt đầu xóa ảnh cũ trên Cloudinary.");

                        bool isDeleted = await _cloudinaryHelper.DeleteImageAsync(existingStudent.Photo);

                        stopwatch.Stop();
                        LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Xóa ảnh cũ trên Cloudinary thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                        if (!isDeleted)
                        {
                            response.Success = false;
                            response.Message = "Không thể xóa ảnh cũ trên Cloudinary.";
                            return response;
                        }
                    }

                    if (studentDto.ImageFile != null)
                    {
                        stopwatch.Restart();
                        LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Bắt đầu đẩy ảnh mới lên Cloudinary.");

                        imageUrl = await _cloudinaryHelper.UploadImageAsync(studentDto.ImageFile, existingStudent.StudentId);

                        stopwatch.Stop();
                        LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Ảnh mới đã được đẩy lên Cloudinary thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                        existingStudent.Photo = imageUrl;
                    }
                    else
                    {
                        LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Không có ảnh mới để upload lên Cloudinary.");
                    }
                }

                stopwatch.Restart();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Bắt đầu cập nhật thông tin sinh viên trong SQL.");

                _mapper.Map(studentDto, existingStudent);
                await _studentRepository.UpdateStudentAsync(existingStudent);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Cập nhật thông tin sinh viên trong SQL thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                stopwatch.Restart();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Bắt đầu cập nhật thông tin sinh viên trong MongoDB.");

                var mgstudent = _mapper.Map<MgStudentDTO>(existingStudent);
                await _mongoStudentRepository.UpdateStudentAsync(mgstudent);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Cập nhật thông tin sinh viên trong MongoDB thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                stopwatch.Restart();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Bắt đầu cập nhật metadata trong hệ thống.");

                await _metadata.UpdateMetadaAsync(made_by, existingStudent.AuditableId, existingStudent.LocationId.Value, 1);

                stopwatch.Stop();
                LogWithColor(ConsoleColor.DarkYellow, $"[{GetVietnamTime()}] Metadata đã được cập nhật thành công. Thời gian thực hiện: {stopwatch.ElapsedMilliseconds} ms.");

                response.Data = true;
                response.Message = "Cập nhật sinh viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Lỗi tổng quát: {ex.Message}");
            }

            return response;
        }


        public async Task<ServiceResponse<bool>> DeleteStudentAsync(string made_by, string id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Bắt đầu lấy thông tin sinh viên với ID: {id}.");
                var student = await _studentRepository.GetStudentByIdAsync(id);
                if (student == null)
                {
                    LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Sinh viên với ID: {id} không tồn tại.");
                    response.Success = false;
                    response.Message = "Sinh viên không tồn tại.";
                    return response;
                }

                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Bắt đầu xóa sinh viên với ID: {id}.");
                await _studentRepository.DeleteStudentAsync(id);

                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Bắt đầu cập nhật metadata cho sinh viên với ID: {id}.");
                await _metadata.UpdateMetadaAsync(made_by, student.AuditableId, student.LocationId.Value, 2);

                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Xóa sinh viên với ID: {id} thành công.");
                response.Data = true;
                response.Message = "Xóa sinh viên thành công.";
            }
            catch (Exception ex)
            {
                LogWithColor(ConsoleColor.Red, $"[{GetVietnamTime()}] Đã xảy ra lỗi khi xóa sinh viên với ID: {id}. Lỗi: {ex.Message}");
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<StudentDTO>>> GetStudentsByFacultyIdAsync(string facultyId)
        {
            var response = new ServiceResponse<IEnumerable<StudentDTO>>();

            try
            {
                var students = await _studentRepository.GetStudentsByFacultyIdAsync(facultyId);
                response.Data = _mapper.Map<IEnumerable<StudentDTO>>(students);
                response.Message = "Lấy danh sách sinh viên theo khoa thành công.";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<StudentScoreDTO>>> GetStudentScoresInSemesterAsync(string studentId, int semesterId)
        {
            var response = new ServiceResponse<IEnumerable<StudentScoreDTO>>();

            try
            {
                var scores = await _studentRepository.GetStudentScoresInSemesterAsync(studentId, semesterId);
                response.Data = scores;
                response.Message = "Lấy danh sách điểm thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<MgStudentDTO>>> GetStudentInMongo(int locationId)
        {
            var response = new ServiceResponse<IEnumerable<MgStudentDTO>>();
            try
            {
                var result = await _mongoStudentRepository.GetAllStudentsAsync(locationId);
                response.Data = result;
                response.Message = "Lấy danh sách trên mongo thành công";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Lỗi không lấy được danh sách";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteStudentinMongo(string studentId, string made_by)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var get_metadaId = await _studentRepository.GetStudentByIdAsync(studentId);
                int? locationId = int.Parse(studentId.Substring(0, 1));
                await _metadata.UpdateMetadaAsync(made_by, get_metadaId.AuditableId, locationId.Value, 2);
                await _mongoStudentRepository.DeleteStudentAsync(studentId);
                
                response.Message = "Xoa thanh cong";
                
            }
            catch
            {
                response.Message = "Xoa that bai";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<StudentWithMetadataDTO>>> GetStudentWithMetadataAsync()
        {
            var response = new ServiceResponse<List<StudentWithMetadataDTO>>();
            try
            {
                var students = await _studentRepository.GetAllStudentsAsync();
                var studentsWithMetadata = new List<StudentWithMetadataDTO>();
                foreach (var student in students)
                {
                    var auditable = await _metadata.GetMetadabyIdAsync(student.AuditableId);
                    var studentWithMetadata = _mapper.Map<StudentWithMetadataDTO>(student);
                    studentWithMetadata.auditable = auditable;
                    studentsWithMetadata.Add(studentWithMetadata);
                }
                response.Data = studentsWithMetadata;
                response.Message = "Lay thong tin day du cua sinh vien thanh cong";

            }
            catch (Exception ex)
            {
                response.Message = "Lay danh sach day du cua sinh vien that bai";
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> Transfer(string transfer_by, int location_id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var sql = await _studentRepository.GetAllStudentsByLocationAsync(location_id);
                foreach (var student in sql)
                {
                    var check = await _mongoStudentRepository.GetStudentByIdAsync(student.StudentId);
                    if (check != null) continue;
                    var mongo = _mapper.Map<MgStudentDTO>(student);
                    await _mongoStudentRepository.AddStudentAsync(mongo);
                    var auditable = new Auditable
                    {
                        auditable_id = student.AuditableId,
                        transfered_at = DateTime.Now,
                        transfered_by = transfer_by,
                        status = 1
                    };
                    await _metadata.AddMetadaAsync(auditable);
                    response.Message = "Phan tan thanh cong";
                    
                }
            }
            catch (Exception ex)
            {
                response.Message = "Phan tan that bai";
                response.Success = false;
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> Restore(string restore_by, int location_id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var mongo = await _mongoStudentRepository.GetAllStudentsAsync(location_id);
                foreach (var student in mongo)
                {
                    var check = await _studentRepository.GetStudentByIdAsync(student.StudentId);
                    if (check != null) continue;
                    var parts = student.StudentId.Split('.');
                    string academicYear_id = parts[1];
                    string idEs = parts[2];
                    string faculty_id = parts[3];
                    var sql = _mapper.Map<Student>(student);
                    sql.IdAcademicYear = academicYear_id;
                    sql.IdEs = idEs;
                    sql.FacultyId = faculty_id;
                    await _studentRepository.CreateStudentAsync(sql);
                    await _metadata.UpdateMetadaAsync(restore_by, student.AuditableId, location_id, 3);
                    response.Message = "Khoi phuc thanh cong";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Khoi phuc that bai";
            }

            return response;
        }
        public async Task<ServiceResponse<List<StudentDTO>>> Search(string search, int location_id)
        {
            var response = new ServiceResponse<List<StudentDTO>>();

            try
            {
                var students = await _studentRepository.Search(search, location_id);
                response.Data = _mapper.Map<List<StudentDTO>>(students);
                response.Message = "Lấy danh sách thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<StudentDTO>>> GetStudentByFacultyAndAcademicYear(string facultyId, string academicyear_id, int location_id)
        {
            var response = new ServiceResponse<List<StudentDTO>>();
            try
            {
                var students = await _studentRepository.GetStudentByFacultyAndAcademicYear(facultyId, academicyear_id, location_id);
                response.Data = _mapper.Map<List<StudentDTO>>(students);
                response.Message = "Lấy danh sách thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return response;
        }
        
        public async Task<ServiceResponse<Auditable>> GetMetadata(string auditable_id)
        {
            var response = new ServiceResponse<Auditable>();
            try
            {
                var result = await _metadata.GetMetadabyIdAsync(auditable_id);
                response.Data = result;
                response.Message = "Lấy metadata thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Lấy metadata thất bại";
            }
            return response;
        }
    }
}
