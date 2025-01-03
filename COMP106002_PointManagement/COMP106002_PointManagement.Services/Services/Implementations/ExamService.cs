using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.CoreHeplers;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        private readonly IMongoExamRepository _mongoExamRepository;
        private readonly IMetadata _metadata;
        public ExamService(IExamRepository examRepository, IMapper mapper, IMongoExamRepository mongoExamRepository, IMetadata metadata)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _mongoExamRepository = mongoExamRepository;
            _metadata = metadata;
        }

        public async Task<ServiceResponse<IEnumerable<ExamDTO>>> GetAllExamsAsync(int location_id)
        {
            var response = new ServiceResponse<IEnumerable<ExamDTO>>();
            try
            {
                var exams = await _examRepository.GetAllExamsAsync(location_id);
                response.Data = _mapper.Map<IEnumerable<ExamDTO>>(exams);
                response.Message = "Lấy danh sách kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<ExamDTO?>> GetExamByIdAsync(string id)
        {
            var response = new ServiceResponse<ExamDTO?>();
            try
            {
                var exam = await _examRepository.GetExamByIdAsync(id);
                if (exam == null)
                {
                    response.Success = false;
                    response.Message = "Kỳ thi không tồn tại.";
                    return response;
                }

                response.Data = _mapper.Map<ExamDTO>(exam);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> CreateExamAsync(ExamCreateUpdateDTO examDto, string made_by, int location_id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var roomAvailable = await _examRepository.IsRoomAvailable(examDto.RoomId, examDto.ExamDate, examDto.TimeSlot, examDto.Duration);
                if (!roomAvailable)
                {
                    response.Success = false;
                    response.Message = "Phòng thi đã được sử dụng trong khoảng thời gian này.";
                    return response;
                }

                if (!string.IsNullOrEmpty(examDto.InvigilatorId))
                {
                    var lecturerAvailable = await _examRepository.IsLecturerAvailableAsync(examDto.InvigilatorId, examDto.ExamDate, examDto.TimeSlot, examDto.Duration);
                    if (!lecturerAvailable)
                    {
                        response.Success = false;
                        response.Message = "Giảng viên đã có lịch dạy vào thời gian này.";
                        return response;
                    }
                }

                var exam = _mapper.Map<Exam>(examDto);
                exam.ExamId = Guid.NewGuid().ToString();
                exam.AuditableId = Guid.NewGuid().ToString();
                exam.LocationId = location_id;
                await _examRepository.CreateExamAsync(exam);
                var mgexam = _mapper.Map<MgExam>(exam);
                await _mongoExamRepository.AddExamInMongo(mgexam);
                var auditable = new Auditable
                {
                    auditable_id = exam.AuditableId,
                    created_at = DateTime.UtcNow,
                    created_by = made_by,
                    status = 1
                };
                await _metadata.AddMetadaAsync(auditable);
                response.Data = true;
                response.Message = "Tạo kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateExamAsync(string id, ExamCreateUpdateDTO examDto, string made_by, int location_id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var existingExam = await _examRepository.GetExamByIdAsync(id);
                if (existingExam == null)
                {
                    response.Success = false;
                    response.Message = "Kỳ thi không tồn tại.";
                    return response;
                }

                var roomAvailable = await _examRepository.IsRoomAvailable(examDto.RoomId, examDto.ExamDate, examDto.TimeSlot, examDto.Duration, id);
                if (!roomAvailable)
                {
                    response.Success = false;
                    response.Message = "Phòng thi đã được sử dụng trong khoảng thời gian này.";
                    return response;
                }

                if (!string.IsNullOrEmpty(examDto.InvigilatorId))
                {
                    var lecturerAvailable = await _examRepository.IsLecturerAvailableAsync(examDto.InvigilatorId, examDto.ExamDate, examDto.TimeSlot, examDto.Duration, id);
                    if (!lecturerAvailable)
                    {
                        response.Success = false;
                        response.Message = "Giảng viên đã có lịch dạy vào thời gian này.";
                        return response;
                    }
                }

                var updatedExam = _mapper.Map(examDto, existingExam);
                var mgexam = _mapper.Map<MgExam>(updatedExam);
                await _examRepository.UpdateExamAsync(updatedExam);
                await _mongoExamRepository.UpdateExaminMongo(mgexam, location_id);
                await _metadata.UpdateMetadaAsync(made_by, updatedExam.AuditableId, location_id, 1);
                response.Data = true;
                response.Message = "Cập nhật kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteExamAsync(string id, string made_by, int location_id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var exam = await _examRepository.GetExamByIdAsync(id);
                if (exam == null)
                {
                    response.Success = false;
                    response.Message = "Kì thi không tồn tại";
                    return response;
                }
                await _examRepository.DeleteExamAsync(id);
                await _metadata.UpdateMetadaAsync(made_by, exam.AuditableId, exam.LocationId.Value, 2);
                response.Data = true;
                response.Message = "Xóa kỳ thi thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<RoomDTO>>> GetAvailableRoomsAsync(DateOnly examDate, TimeOnly timeSlot, int? duration, int locationid, string excludeExamId = null)
        {
            var response = new ServiceResponse<IEnumerable<RoomDTO>>();

            try
            {
                if (!duration.HasValue)
                {
                    response.Success = false;
                    response.Message = "Không thể gợi ý phòng vì không có thời lượng thi.";
                    return response;
                }

                var availableRooms = await _examRepository.GetAvailableRoomsAsync(examDate, timeSlot, duration.Value, locationid, excludeExamId);
                response.Data = _mapper.Map<IEnumerable<RoomDTO>>(availableRooms);
                response.Message = "Danh sách phòng trống được gợi ý thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<LecturerDTO>>> GetAvailableLecturersAsync(DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null)
        {
            var response = new ServiceResponse<IEnumerable<LecturerDTO>>();

            try
            {
                var availableLecturers = await _examRepository.GetAvailableLecturersAsync(examDate, timeSlot, duration, excludeExamId);
                response.Data = _mapper.Map<IEnumerable<LecturerDTO>>(availableLecturers);
                response.Message = "Danh sách giảng viên trống được gợi ý thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ExamDTO>>> GetExamsByFacultyIdAsync(string facultyId, int location_id)
        {
            var response = new ServiceResponse<IEnumerable<ExamDTO>>();
            try
            {
                var exams = await _examRepository.GetExamsByFacultyIdAsync(facultyId, location_id);
                response.Data = _mapper.Map<IEnumerable<ExamDTO>>(exams);
                response.Message = "Lấy danh sách kỳ thi theo khoa thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<SimplifiedLecturerDTO>>> GetLecturersByExamIdAsync(string examId)
        {
            var response = new ServiceResponse<IEnumerable<SimplifiedLecturerDTO>>();

            try
            {
                var lecturers = await _examRepository.GetLecturersByExamIdAsync(examId);

                if (lecturers == null || !lecturers.Any())
                {
                    response.Success = false;
                    response.Message = "Không tìm thấy giảng viên nào dạy môn học trong kỳ thi này.";
                    return response;
                }

                response.Data = _mapper.Map<IEnumerable<SimplifiedLecturerDTO>>(lecturers);
                response.Message = "Lấy danh sách giảng viên thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> Transfer(string transfer_by, int location_id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var sql = await _examRepository.GetAllExamsAsync(location_id);
                foreach (var exam in sql)
                {
                    var check = await _mongoExamRepository.GetExamInMongo(exam.ExamId, exam.LocationId.Value);
                    if (check != null) continue;
                    var mongo = _mapper.Map<MgExam>(exam);
                    await _mongoExamRepository.AddExamInMongo(mongo);
                    var auditable = new Auditable
                    {
                        auditable_id = exam.AuditableId,
                        transfered_at = DateTime.Now,
                        transfered_by = transfer_by,
                        status = 1
                    };
                    await _metadata.AddMetadaAsync(auditable);
                    response.Message = "Phân tán thành công";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Phân tán thất bại";
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> Restore(string restore_by, int location_id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var mongo = await _mongoExamRepository.GetAllExamInMongo(location_id);
                foreach (var exam in mongo)
                {
                    var check = await _examRepository.GetExamByIdAsync(exam.ExamId);
                    if (check != null) continue;
                    var sql = _mapper.Map<Exam>(exam);
                    await _examRepository.CreateExamAsync(sql);
                    response.Message = "Khôi phục thành công";
                    await _metadata.UpdateMetadaAsync(restore_by, exam.AuditableId, location_id, 3);
                }
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = "Khôi phục thất bại";
            }
            return response;
        }
    }
}
