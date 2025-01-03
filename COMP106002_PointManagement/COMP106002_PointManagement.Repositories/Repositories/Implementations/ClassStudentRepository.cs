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
    public class ClassStudentRepository : IClassStudentRepository
    {
        private readonly PM_App _context;

        public ClassStudentRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassStudent>> GetClassStudentsByClassIdAsync(string classId)
        {
            return await _context.ClassStudents
                .Include(cs => cs.Class)
                .Include(cs => cs.Student)
                .Where(cs => cs.ClassId == classId)
                .ToListAsync();
        }

        public async Task<ClassStudent?> GetClassStudentByIdAsync(string id)
        {
            return await _context.ClassStudents
                .Include(cs => cs.Class)
                .Include(cs => cs.Student)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task AddClassStudentAsync(ClassStudent classStudent)
        {
            classStudent.Id = Guid.NewGuid().ToString();
            await _context.ClassStudents.AddAsync(classStudent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassStudentAsync(ClassStudent classStudent)
        {
            _context.ClassStudents.Update(classStudent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassStudentAsync(ClassStudent classStudent)
        {
            _context.ClassStudents.Remove(classStudent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassQuantityAsync(string classId, int delta)
        {
            var classEntity = await _context.Classes.FindAsync(classId);
            if (classEntity != null)
            {
                classEntity.Quantity += delta;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Student>> GetStudentsNotInSubjectAsync(string subjectId)
        {
            // Lấy FacultyId của môn học
            var facultyId = await _context.Subjects
                .Where(s => s.SubjectId == subjectId)
                .Select(s => s.FacultyId)
                .FirstOrDefaultAsync();

            if (facultyId == null)
            {
                throw new Exception("Subject không hợp lệ.");
            }

            // Lấy danh sách sinh viên chưa học môn này
            var students = await _context.Students
                .Where(s => s.FacultyId == facultyId &&
                            !_context.ClassStudents
                                .Where(cs => cs.Class != null && cs.Class.IdLectuerSubjectNavigation.SubjectId == subjectId)
                                .Select(cs => cs.StudentId)
                                .Contains(s.StudentId))
                .ToListAsync();

            return students;
        }
    }
}
