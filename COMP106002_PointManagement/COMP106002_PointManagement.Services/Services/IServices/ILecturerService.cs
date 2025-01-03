using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface ILecturerService
    {
        Task<ServiceResponse<IEnumerable<LecturerDTO>>> GetAllLecturersAsync();
        Task<ServiceResponse<bool>> CreateLecturerAsync(LecturerCreateUpdateDTO lecturerDto);
        Task<ServiceResponse<bool>> UpdateLecturerAsync(string id, LecturerCreateUpdateDTO lecturerDto);
        Task<ServiceResponse<bool>> DeleteLecturerAsync(string id);
        Task<ServiceResponse<LecturerDTO>> GetLecturerByIdAsync(string id);
    }
}
