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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LocationDTO>> GetLocationbyId(int locationId)
        {
            var response = new ServiceResponse<LocationDTO>();
            try
            {
                var result = await _locationRepository.GetLocationById(locationId);
                var mapper = _mapper.Map<LocationDTO>(result);
                response.Data = mapper;
                response.Message = "Lấy theo locationId thành công";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = "Lấy thất bại";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<LocationDTO>>> GetLocations()
        {
            var response = new ServiceResponse<List<LocationDTO>>();
            try
            {
                var result = await _locationRepository.GetAllLocations();
                var mapper = _mapper.Map<List<LocationDTO>>(result);
                response.Data = mapper;
                response.Message = "Lấy thành công danh sách location thành công";
            }
            catch (Exception ex)
            {
                response.Data = new List<LocationDTO>();
                response.Message = "Lấy danh sách location thất bại";
                response.Success = false;
            }
            return response;
        }
    }
}
