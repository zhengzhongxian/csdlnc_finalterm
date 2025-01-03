using AutoMapper;
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
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public FacultyService(IFacultyRepository facultyRepository, IMapper mapper)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<FacultyDTO>>> GetAllFacultiesAsync()
        {
            var response = new ServiceResponse<IEnumerable<FacultyDTO>>();

            try
            {
                var faculties = await _facultyRepository.GetAllFacultiesAsync();
                response.Data = _mapper.Map<IEnumerable<FacultyDTO>>(faculties);
                response.Message = "Lấy danh sách khoa thành công.";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<FacultyDTO>> GetFacultyByIdAsync(string id)
        {
            var response = new ServiceResponse<FacultyDTO>();

            try
            {
                var faculty = await _facultyRepository.GetFacultyByIdAsync(id);
                if (faculty == null)
                {
                    response.Success = false;
                    response.Message = "Khoa không tồn tại.";
                    return response;
                }

                response.Data = _mapper.Map<FacultyDTO>(faculty);
                response.Message = "Lấy thông tin khoa thành công.";
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = $"Đã xảy ra lỗi: {ex.Message}";
            }

            return response;
        }
    }
}
