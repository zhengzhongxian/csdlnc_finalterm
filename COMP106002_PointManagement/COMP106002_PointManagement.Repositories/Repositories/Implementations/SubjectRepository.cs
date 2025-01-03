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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly PM_App _context;

        public SubjectRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects
                .Include(s => s.Faculty)
                .ToListAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(string id)
        {
            return await _context.Subjects
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(string id)
        {
            var subject = await GetSubjectByIdAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsSubjectNameExistsAsync(string subjectName, string? excludeSubjectId = null)
        {
            return await _context.Subjects.AnyAsync(s =>
                s.SubjectName == subjectName && (excludeSubjectId == null || s.SubjectId != excludeSubjectId));
        }
    }
}
