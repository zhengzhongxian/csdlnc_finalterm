using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface ILecturerSubjectRepository
    {
        Task<IEnumerable<LecturerSubject>> GetLecturerSubjectsBySubjectIdAsync(string subjectId);
        Task AddLecturerSubjectAsync(LecturerSubject lecturerSubject);
        //Task UpdateLecturerSubjectAsync(LecturerSubject lecturerSubject);
        Task DeleteLecturerSubjectAsync(string id);
    }
}
