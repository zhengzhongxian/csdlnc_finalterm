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
    public class ClassRepository : IClassRepository
    {
        private readonly PM_App _context;

        public ClassRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Classes
                .Include(c => c.IdEsNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Lecturer)
                        .ThenInclude(l => l.LecturerNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Subject)
                .ToListAsync();
        }

        public async Task<Class?> GetClassByIdAsync(string classId)
        {
            return await _context.Classes
                .Include(c => c.IdEsNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Lecturer)
                        .ThenInclude(l => l.LecturerNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Subject)
                .FirstOrDefaultAsync(c => c.ClassId == classId);
        }

        public async Task<IEnumerable<Class>> GetClassesByFacultyIdAsync(string facultyId, int location_id)
        {
            return await _context.Classes
                .Include(c => c.IdEsNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Lecturer)
                        .ThenInclude(l => l.LecturerNavigation)
                .Include(c => c.IdLectuerSubjectNavigation)
                    .ThenInclude(ls => ls.Subject)
                .Where(c => c.IdLectuerSubjectNavigation.Subject.FacultyId == facultyId && c.LocationId == location_id)
                .ToListAsync();
        }

        public async Task AddClassAsync(Class newClass)
        {

            await _context.Classes.AddAsync(newClass);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(Class updatedClass)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.ClassId == updatedClass.ClassId);

            if (existingClass == null)
                throw new Exception("Không tìm thấy lớp cần cập nhật.");
            //existingClass.Quantity = updatedClass.Quantity;
            existingClass.StartDate = updatedClass.StartDate;
            existingClass.EndDate = updatedClass.EndDate;

            if (existingClass.IdLectuerSubject != updatedClass.IdLectuerSubject)
            {
                var lecturerSubject = await _context.LecturerSubjects
                    .Include(ls => ls.Subject)
                    .FirstOrDefaultAsync(ls => ls.Id == updatedClass.IdLectuerSubject);

                if (lecturerSubject?.SubjectId != null)
                {
                    existingClass.ClassName = await GenerateClassNameAsync(lecturerSubject.SubjectId);
                }
            }

            existingClass.IdEs = updatedClass.IdEs;
            existingClass.IdLectuerSubject = updatedClass.IdLectuerSubject;

            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(string classId)
        {
            var classEntity = await _context.Classes.FindAsync(classId);
            if (classEntity != null)
            {
                _context.Classes.Remove(classEntity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string> GenerateClassNameAsync(string subjectId)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);

            if (subject == null || string.IsNullOrEmpty(subject.SubjectName))
                throw new Exception("Môn học không tồn tại hoặc không có tên.");

            var subjectCode = string.Concat(subject.SubjectName
                .Split(' ')
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => word[0]))
                .ToUpper();

            var baseClassName = $"{subjectCode}-HCMUE";

            var existingClasses = await _context.Classes
                .Where(c => c.ClassName.StartsWith(baseClassName))
                .Select(c => c.ClassName)
                .ToListAsync();

            var maxSuffix = existingClasses
                .Select(name => int.TryParse(name.Replace(baseClassName, "").TrimStart('0'), out var suffix) ? suffix : 0)
                .DefaultIfEmpty(0)
                .Max();

            var newClassName = $"{baseClassName}{(maxSuffix + 1).ToString("D2")}";
            return newClassName;
        }

        public async Task<LecturerSubject?> GetLecturerSubjectWithSubjectAsync(string lecturerSubjectId)
        {
            return await _context.LecturerSubjects
                .Include(ls => ls.Subject)
                .FirstOrDefaultAsync(ls => ls.Id == lecturerSubjectId);
        }

    }
}
