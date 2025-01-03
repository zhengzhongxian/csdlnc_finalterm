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
    public class EducationSystemService : IEducationSystemService
    {
        private readonly IEducationSystemRepository _educationSystemRepository;
        private readonly IMapper _mapper;

        public EducationSystemService(IEducationSystemRepository educationSystemRepository, IMapper mapper)
        {
            _educationSystemRepository = educationSystemRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<EducationSystemDTO>>> GetAllEducationSystemsAsync()
        {
            var response = new ServiceResponse<IEnumerable<EducationSystemDTO>>();
            try
            {
                var educationSystems = await _educationSystemRepository.GetAllEducationSystemsAsync();
                response.Data = _mapper.Map<IEnumerable<EducationSystemDTO>>(educationSystems);
                response.Message = "Lấy danh sách hệ thống giáo dục thành công.";
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
