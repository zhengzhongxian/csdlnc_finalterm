using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IClassStudentRepository
    {
        Task<IEnumerable<ClassStudent>> GetClassStudentsByClassIdAsync(string classId);
        Task<ClassStudent?> GetClassStudentByIdAsync(string id);
        Task AddClassStudentAsync(ClassStudent classStudent);
        Task UpdateClassStudentAsync(ClassStudent classStudent);
        Task DeleteClassStudentAsync(ClassStudent classStudent);
        Task UpdateClassQuantityAsync(string classId, int delta);
        Task<IEnumerable<Student>> GetStudentsNotInSubjectAsync(string subjectId);
    }
}
