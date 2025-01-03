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
    public interface ISubjectService
    {
        Task<ServiceResponse<IEnumerable<SubjectDTO>>> GetAllSubjectsAsync();
        Task<ServiceResponse<SubjectDTO>> GetSubjectByIdAsync(string id);
        Task<ServiceResponse<bool>> CreateSubjectAsync(SubjectCreateUpdateDTO subjectDto);
        Task<ServiceResponse<bool>> UpdateSubjectAsync(string id, SubjectCreateUpdateDTO subjectDto);
        Task<ServiceResponse<bool>> DeleteSubjectAsync(string id);
    }
}
