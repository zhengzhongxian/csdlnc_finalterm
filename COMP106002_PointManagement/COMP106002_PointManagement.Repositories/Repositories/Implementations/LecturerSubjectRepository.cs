using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class LecturerSubjectRepository : ILecturerSubjectRepository
    {
        private readonly PM_App _context;

        public LecturerSubjectRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LecturerSubject>> GetLecturerSubjectsBySubjectIdAsync(string subjectId)
        {
            return await _context.LecturerSubjects
                .Include(ls => ls.Lecturer)
                    .ThenInclude(l => l.LecturerNavigation)
                .Where(ls => ls.SubjectId == subjectId)
                .ToListAsync();
        }

        public async Task AddLecturerSubjectAsync(LecturerSubject lecturerSubject)
        {
            lecturerSubject.Id = Guid.NewGuid().ToString();
            await _context.LecturerSubjects.AddAsync(lecturerSubject);
            await _context.SaveChangesAsync();
        }

        /*public async Task UpdateLecturerSubjectAsync(LecturerSubject lecturerSubject)
        {
            _context.LecturerSubjects.Update(lecturerSubject);
            await _context.SaveChangesAsync();
        }*/

        public async Task DeleteLecturerSubjectAsync(string id)
        {
            var entity = await _context.LecturerSubjects.FindAsync(id);
            if (entity != null)
            {
                _context.LecturerSubjects.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
