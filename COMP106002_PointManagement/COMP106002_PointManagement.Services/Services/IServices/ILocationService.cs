using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface ILocationService
    {
        Task<ServiceResponse<List<LocationDTO>>> GetLocations();
        Task<ServiceResponse<LocationDTO>> GetLocationbyId(int locationId);
    }
}
