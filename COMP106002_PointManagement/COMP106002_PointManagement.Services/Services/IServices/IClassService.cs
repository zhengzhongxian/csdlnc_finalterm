using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IClassService
    {
        Task<ServiceResponse<IEnumerable<ClassDTO>>> GetAllClassesAsync();
        Task<ServiceResponse<ClassDTO>> GetClassByIdAsync(string classId);
        Task<ServiceResponse<IEnumerable<ClassDTO>>> GetClassesByFacultyIdAsync(string facultyId, int location_id);
        Task<ServiceResponse<bool>> AddClassAsync(ClassCreateDTO classDto, int location_id, string made_by);
        Task<ServiceResponse<bool>> UpdateClassAsync(string classId, ClassUpdateDTO classDto, string made_by);
        Task<ServiceResponse<bool>> DeleteClassAsync(string classId, string made_by);
    }
}
