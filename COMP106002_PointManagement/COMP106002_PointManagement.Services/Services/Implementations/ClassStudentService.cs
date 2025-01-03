using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
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
    public class ClassStudentService : IClassStudentService
    {
        private readonly IClassStudentRepository _repository;
        private readonly IMapper _mapper;

        public ClassStudentService(IClassStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<ClassStudentDTO>>> GetClassStudentsByClassIdAsync(string classId)
        {
            var response = new ServiceResponse<IEnumerable<ClassStudentDTO>>();
            try
            {
                var data = await _repository.GetClassStudentsByClassIdAsync(classId);
                response.Data = _mapper.Map<IEnumerable<ClassStudentDTO>>(data);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<ClassStudentDTO>> GetClassStudentByIdAsync(string id)
        {
            var response = new ServiceResponse<ClassStudentDTO>();
            try
            {
                var data = await _repository.GetClassStudentByIdAsync(id);
                response.Data = _mapper.Map<ClassStudentDTO>(data);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> AddClassStudentAsync(ClassStudentCreateDTO classStudentDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var entity = _mapper.Map<ClassStudent>(classStudentDto);
                await _repository.AddClassStudentAsync(entity);
                await _repository.UpdateClassQuantityAsync(classStudentDto.ClassId!, 1);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateClassStudentAsync(string id, ClassStudentUpdateDTO classStudentDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var entity = await _repository.GetClassStudentByIdAsync(id);
                if (entity == null) throw new Exception("ClassStudent not found.");

                _mapper.Map(classStudentDto, entity);
                await _repository.UpdateClassStudentAsync(entity);
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteClassStudentAsync(string id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var entity = await _repository.GetClassStudentByIdAsync(id);
                if (entity == null) throw new Exception("ClassStudent not found.");

                await _repository.DeleteClassStudentAsync(entity);
                await _repository.UpdateClassQuantityAsync(entity.ClassId!, -1); // Giảm quantity
                response.Data = true;
                response.Message = "Xóa thành công";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<OtherStudentDTO>>> GetStudentsNotInSubjectAsync(string subjectId)
        {
            var response = new ServiceResponse<IEnumerable<OtherStudentDTO>>();
            try
            {
                var students = await _repository.GetStudentsNotInSubjectAsync(subjectId);
                response.Data = _mapper.Map<IEnumerable<OtherStudentDTO>>(students);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
