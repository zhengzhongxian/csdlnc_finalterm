using AutoMapper;
using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.CU_DTO;
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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<SubjectDTO>>> GetAllSubjectsAsync()
        {
            var response = new ServiceResponse<IEnumerable<SubjectDTO>>();
            try
            {
                var subjects = await _subjectRepository.GetAllSubjectsAsync();
                response.Data = _mapper.Map<IEnumerable<SubjectDTO>>(subjects);
                response.Message = "Lấy danh sách môn học thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<SubjectDTO>> GetSubjectByIdAsync(string id)
        {
            var response = new ServiceResponse<SubjectDTO>();
            try
            {
                var subject = await _subjectRepository.GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    response.Success = false;
                    response.Message = "Môn học không tồn tại.";
                    return response;
                }

                response.Data = _mapper.Map<SubjectDTO>(subject);
                response.Message = "Lấy thông tin môn học thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> CreateSubjectAsync(SubjectCreateUpdateDTO subjectDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                if (await _subjectRepository.IsSubjectNameExistsAsync(subjectDto.SubjectName))
                {
                    response.Success = false;
                    response.Message = "Tên môn học đã tồn tại.";
                    return response;
                }

                var subject = _mapper.Map<Subject>(subjectDto);
                subject.SubjectId = Guid.NewGuid().ToString();

                await _subjectRepository.CreateSubjectAsync(subject);
                response.Data = true;
                response.Message = "Môn học đã được tạo thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateSubjectAsync(string id, SubjectCreateUpdateDTO subjectDto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var existingSubject = await _subjectRepository.GetSubjectByIdAsync(id);
                if (existingSubject == null)
                {
                    response.Success = false;
                    response.Message = "Môn học không tồn tại.";
                    return response;
                }

                if (await _subjectRepository.IsSubjectNameExistsAsync(subjectDto.SubjectName, id))
                {
                    response.Success = false;
                    response.Message = "Tên môn học đã tồn tại.";
                    return response;
                }

                var updatedSubject = _mapper.Map(subjectDto, existingSubject);
                await _subjectRepository.UpdateSubjectAsync(updatedSubject);

                response.Data = true;
                response.Message = "Cập nhật môn học thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteSubjectAsync(string id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                await _subjectRepository.DeleteSubjectAsync(id);
                response.Data = true;
                response.Message = "Xóa môn học thành công.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
    }
}
