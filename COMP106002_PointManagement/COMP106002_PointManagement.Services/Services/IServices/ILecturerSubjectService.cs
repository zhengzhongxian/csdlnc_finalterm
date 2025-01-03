using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface ILecturerSubjectService
    {
        Task<ServiceResponse<IEnumerable<LecturerSubjectDTO>>> GetLecturerSubjectsBySubjectIdAsync(string subjectId);
        Task<ServiceResponse<bool>> AddLecturerSubjectAsync(LecturerSubjectCreateDTO lecturerSubjectDto);
        //Task<ServiceResponse<bool>> UpdateLecturerSubjectAsync(string id, LecturerSubjectUpdateDTO lecturerSubjectDto);
        Task<ServiceResponse<bool>> DeleteLecturerSubjectAsync(string id);
    }
}
