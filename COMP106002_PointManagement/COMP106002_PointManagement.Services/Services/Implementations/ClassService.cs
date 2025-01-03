using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.CoreHeplers;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.MongoDTO;
using COMP106002_PointManagement.Repositories.MongoRepositories.Implementations;
using COMP106002_PointManagement.Repositories.MongoRepositories.IRepositoties;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using COMP106002_PointManagement.Services.Models;
using COMP106002_PointManagement.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        private readonly IMongoClassRepository _mongoClassRepository;
        private readonly IMetadata _metadata;

        public ClassService(IClassRepository classRepository, IMapper mapper, IMongoClassRepository mongoClassRepository, IMetadata metadata)
        {
            _classRepository = classRepository;
            _mapper = mapper;
            _mongoClassRepository = mongoClassRepository;
            _metadata = metadata;
        }

        public async Task<ServiceResponse<IEnumerable<ClassDTO>>> GetAllClassesAsync()
        {
            var response = new ServiceResponse<IEnumerable<ClassDTO>>();
            try
            {
                var classes = await _classRepository.GetAllClassesAsync();
                response.Data = _mapper.Map<IEnumerable<ClassDTO>>(classes);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<ClassDTO>> GetClassByIdAsync(string classId)
        {
            var response = new ServiceResponse<ClassDTO>();
            try
            {
                var classEntity = await _classRepository.GetClassByIdAsync(classId);
                response.Data = _mapper.Map<ClassDTO>(classEntity);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ClassDTO>>> GetClassesByFacultyIdAsync(string facultyId, int location_id)
        {
            var response = new ServiceResponse<IEnumerable<ClassDTO>>();
            try
            {
                var classes = await _classRepository.GetClassesByFacultyIdAsync(facultyId, location_id);
                response.Data = _mapper.Map<IEnumerable<ClassDTO>>(classes);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> AddClassAsync(ClassCreateDTO classDto, int location_id, string made_by)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var newClass = _mapper.Map<Class>(classDto);
                newClass.ClassId = Guid.NewGuid().ToString();
                newClass.Quantity = 0;
                if (!string.IsNullOrEmpty(newClass.IdLectuerSubject))
                {
                    var lecturerSubject = await _classRepository.GetLecturerSubjectWithSubjectAsync(newClass.IdLectuerSubject);

                    if (lecturerSubject?.SubjectId != null)
                    {
                        newClass.ClassName = await _classRepository.GenerateClassNameAsync(lecturerSubject.SubjectId);
                    }
                }
                newClass.LocationId = location_id;
                newClass.AuditableId = Guid.NewGuid().ToString();
                await _classRepository.AddClassAsync(newClass);
                var mongo = _mapper.Map<MgClass>(newClass);
                await _mongoClassRepository.AddClass(mongo);
                var auditable = new Auditable
                {
                    auditable_id = mongo.AuditableId,
                    created_at = DateTime.UtcNow,
                    created_by = made_by,
                    status = 1
                };
                await _metadata.AddMetadaAsync(auditable);
                response.Data = true;
                response.Message = "Thêm lớp học thành công!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi khi thêm lớp học: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateClassAsync(string classId, ClassUpdateDTO classDto, string made_by)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var updatedClass = _mapper.Map<Class>(classDto);
                updatedClass.ClassId = classId;     
                await _classRepository.UpdateClassAsync(updatedClass);
                var sql = await _classRepository.GetClassByIdAsync(updatedClass.ClassId);
                var mongo = _mapper.Map<MgClass>(sql);
                await _mongoClassRepository.UpdateClass(mongo);
                await _metadata.UpdateMetadaAsync(made_by, sql.AuditableId, sql.LocationId.Value, 1);
                response.Data = true;
                response.Message = "Cập nhật lớp học thành công!";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteClassAsync(string classId, string made_by)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var sql = await _classRepository.GetClassByIdAsync(classId);
                await _classRepository.DeleteClassAsync(classId);
                await _metadata.UpdateMetadaAsync(made_by, sql.AuditableId, sql.LocationId.Value, 2);
                response.Data = true;
                response.Message = "Xóa lớp học thành công!";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
