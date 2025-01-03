using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IClassStudentService
    {
        Task<ServiceResponse<IEnumerable<ClassStudentDTO>>> GetClassStudentsByClassIdAsync(string classId);
        Task<ServiceResponse<ClassStudentDTO>> GetClassStudentByIdAsync(string id);
        Task<ServiceResponse<bool>> AddClassStudentAsync(ClassStudentCreateDTO classStudentDto);
        Task<ServiceResponse<bool>> UpdateClassStudentAsync(string id, ClassStudentUpdateDTO classStudentDto);
        Task<ServiceResponse<bool>> DeleteClassStudentAsync(string id);
        Task<ServiceResponse<IEnumerable<OtherStudentDTO>>> GetStudentsNotInSubjectAsync(string subjectId);
    }
}
