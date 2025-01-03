using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PM_App _context;

        public StudentRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetAllStudentsByLocationAsync(int location_id)
        {
            return await _context.Students
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .Where(s => s.LocationId == location_id)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(string id)
        {
            return await _context.Students
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task CreateStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(string id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEmailOrPhoneExistsAsync(string email, string phoneNumber, string? excludeStudentId = null)
        {
            return await _context.Students.AnyAsync(s =>
                (s.Email == email || s.PhoneNumber == phoneNumber) && (excludeStudentId == null || s.StudentId != excludeStudentId));
        }

        public async Task<string> GenerateStudentIdAsync(string? academicYearId, string? educationSystemId, string? facultyId, int locationId)
        {
            if (string.IsNullOrEmpty(academicYearId) || string.IsNullOrEmpty(educationSystemId) || string.IsNullOrEmpty(facultyId))
            {
                throw new ArgumentException("Missing academic year, education system, or faculty information.");
            }

            var existingStudents = await _context.Students
                .Where(s => s.IdAcademicYear == academicYearId && s.IdEs == educationSystemId 
                && s.FacultyId == facultyId && s.LocationId == locationId)
                .ToListAsync();

            int maxNumber = existingStudents.Count > 0
                ? existingStudents.Select(s => int.Parse(s.StudentId.Split('.').Last())).Max()
                : 0;

            string newId = $"{locationId}.{academicYearId}.{educationSystemId}.{facultyId}.{(maxNumber + 1).ToString("D3")}";
            return newId;
        }
        public async Task<IEnumerable<Student>> GetStudentsByFacultyIdAsync(string facultyId)
        {
            return await _context.Students
                .Where(s => s.FacultyId == facultyId)
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .ToListAsync();
        }
        public async Task<IEnumerable<StudentScoreDTO>> GetStudentScoresInSemesterAsync(string studentId, int semesterId)
        {
            var scores = await _context.Subjects
                .Where(s => s.SemesterId == semesterId)
                .SelectMany(subject => _context.Classes
                    .Where(c => c.IdLectuerSubjectNavigation.SubjectId == subject.SubjectId)
                    .SelectMany(cls => _context.ClassStudents
                        .Where(cs => cs.ClassId == cls.ClassId && cs.StudentId == studentId)
                        .Select(cs => new
                        {
                            SubjectName = subject.SubjectName,
                            ClassScore = cs.Score,
                            ExamScore = _context.ExamResults
                                .Where(er => er.StudentId == studentId && er.Exam.SubjectId == subject.SubjectId)
                                .Select(er => er.Score)
                                .FirstOrDefault(),
                            ProcessScore = subject.Typescore.ProcessScore ?? 0,
                            EndScore = subject.Typescore.EndScore ?? 0
                        })
                    )
                )
                .ToListAsync();

            return scores.Select(s => new StudentScoreDTO
            {
                SubjectName = s.SubjectName,
                ClassScore = s.ClassScore,
                ExamScore = s.ExamScore,
                ScoreSystem10 = s.ClassScore.HasValue && s.ExamScore.HasValue
                    ? (s.ClassScore.Value * s.ProcessScore / 100) + (s.ExamScore.Value * s.EndScore / 100)
                    : null,
                ScoreSystem4 = s.ClassScore.HasValue && s.ExamScore.HasValue
                    ? ConvertTo4PointScale((s.ClassScore.Value * s.ProcessScore / 100) + (s.ExamScore.Value * s.EndScore / 100))
                    : null
            });
        }

        private static decimal ConvertTo4PointScale(decimal scoreSystem10)
        {
            if (scoreSystem10 >= 8.5m) return 4.0m;
            if (scoreSystem10 >= 7.5m) return 3.5m;
            if (scoreSystem10 >= 6.5m) return 3.0m;
            if (scoreSystem10 >= 5.5m) return 2.5m;
            if (scoreSystem10 >= 4.5m) return 2.0m;
            if (scoreSystem10 >= 3.5m) return 1.5m;
            if (scoreSystem10 >= 2.5m) return 1.0m;
            return 0.0m;
        }

        public async Task<List<Student>> Search(string search, int location_id)
        {
            return await _context.Students
                .Where(s =>
                    (string.IsNullOrEmpty(search) ||
                    s.StudentId.Contains(search) ||
                    s.StudentName.Contains(search)) && s.LocationId == location_id
                )
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .ToListAsync();
        }

        //lọc danh sách sinh viên theo Khóa (Academic Year) và Khoa (Faculty)
        public async Task<List<Student>> GetStudentByFacultyAndAcademicYear(string facultyId, string academicyear_id, int location_id)
        {
            return await _context.Students
                .Where(s =>
                    (string.IsNullOrEmpty(facultyId) || s.FacultyId == facultyId) &&
                    (string.IsNullOrEmpty(academicyear_id) || s.IdAcademicYear == academicyear_id)
                    && s.LocationId == location_id
                )
                .Include(s => s.IdAcademicYearNavigation)
                .Include(s => s.IdEsNavigation)
                .Include(s => s.Faculty)
                .ToListAsync();
        }
    }
}
