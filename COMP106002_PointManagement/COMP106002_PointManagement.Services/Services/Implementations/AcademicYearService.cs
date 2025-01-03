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
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IMapper _mapper;

        public AcademicYearService(IAcademicYearRepository academicYearRepository, IMapper mapper)
        {
            _academicYearRepository = academicYearRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<AcademicYearDTO>>> GetAllAcademicYearsAsync()
        {
            var response = new ServiceResponse<IEnumerable<AcademicYearDTO>>();
            try
            {
                var academicYears = await _academicYearRepository.GetAllAcademicYearsAsync();
                response.Data = _mapper.Map<IEnumerable<AcademicYearDTO>>(academicYears);
                response.Message = "Lấy danh sách năm học thành công.";
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
