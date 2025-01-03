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
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _repository;
        private readonly IMapper _mapper;

        public SemesterService(ISemesterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<SemesterDTO>>> GetAllSemestersAsync()
        {
            var response = new ServiceResponse<IEnumerable<SemesterDTO>>();
            try
            {
                var semesters = await _repository.GetAllSemestersAsync();
                response.Data = _mapper.Map<IEnumerable<SemesterDTO>>(semesters);
                response.Message = "Lấy danh sách học kỳ thành công.";
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
