using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
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
    public class LecturerSubjectService : ILecturerSubjectService
    {
        private readonly ILecturerSubjectRepository _repository;
        private readonly IMapper _mapper;

        public LecturerSubjectService(ILecturerSubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<LecturerSubjectDTO>>> GetLecturerSubjectsBySubjectIdAsync(string subjectId)
        {
            var response = new ServiceResponse<IEnumerable<LecturerSubjectDTO>>();
            try
            {
                var data = await _repository.GetLecturerSubjectsBySubjectIdAsync(subjectId);
                response.Data = _mapper.Map<IEnumerable<LecturerSubjectDTO>>(data);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> AddLecturerSubjectAsync(LecturerSubjectCreateDTO lecturerSubjectDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var entity = _mapper.Map<LecturerSubject>(lecturerSubjectDto);
                await _repository.AddLecturerSubjectAsync(entity);
                response.Data = true;
                response.Message = "Added successfully!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /*public async Task<ServiceResponse<bool>> UpdateLecturerSubjectAsync(string id, LecturerSubjectUpdateDTO lecturerSubjectDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var entity = _mapper.Map<LecturerSubject>(lecturerSubjectDto);
                entity.Id = id;
                await _repository.UpdateLecturerSubjectAsync(entity);
                response.Data = true;
                response.Message = "Updated successfully!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }*/

        public async Task<ServiceResponse<bool>> DeleteLecturerSubjectAsync(string id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                await _repository.DeleteLecturerSubjectAsync(id);
                response.Data = true;
                response.Message = "Deleted successfully!";
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
