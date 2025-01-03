using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class?> GetClassByIdAsync(string classId);
        Task<IEnumerable<Class>> GetClassesByFacultyIdAsync(string facultyId, int location_id);
        Task AddClassAsync(Class newClass);
        Task UpdateClassAsync(Class updatedClass);
        Task DeleteClassAsync(string classId);
        Task<string> GenerateClassNameAsync(string subjectId);
        Task<LecturerSubject?> GetLecturerSubjectWithSubjectAsync(string lecturerSubjectId);

    }
}
