using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IFacultyService
    {
        Task<ServiceResponse<IEnumerable<FacultyDTO>>> GetAllFacultiesAsync();
        Task<ServiceResponse<FacultyDTO>> GetFacultyByIdAsync(string id);
    }
}
