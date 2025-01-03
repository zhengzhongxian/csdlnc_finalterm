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
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly PM_App _context;

        public ExamResultRepository(PM_App context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResultsAsync()
        {
            return await _context.ExamResults
                .Include(er => er.Student)
                .Include(er => er.Exam)
                .ToListAsync();
        }

        public async Task<ExamResult?> GetExamResultByIdAsync(string resultId)
        {
            return await _context.ExamResults
                .Include(er => er.Student)
                .Include(er => er.Exam)
                .FirstOrDefaultAsync(er => er.ResultId == resultId);
        }

        public async Task CreateExamResultAsync(ExamResult examResult)
        {
            examResult.ResultId = Guid.NewGuid().ToString();
            _context.ExamResults.Add(examResult);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExamResultAsync(ExamResult examResult)
        {
            _context.ExamResults.Update(examResult);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExamResultAsync(string resultId)
        {
            var result = await GetExamResultByIdAsync(resultId);
            if (result != null)
            {
                _context.ExamResults.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        // New methods

        // Lấy danh sách các kỳ thi mà một giảng viên chấm
        public async Task<IEnumerable<Exam>> GetExamsByLecturerAsync(string lecturerId)
        {
            return await _context.Exams
                .Where(e => e.InvigilatorId == lecturerId)
                .ToListAsync();
        }

        // Lấy danh sách sinh viên mà giảng viên chấm trong một kỳ thi
        public async Task<IEnumerable<ExamResult>> GetStudentsByLecturerInExamAsync(string lecturerId, string examId)
        {
            return await _context.ExamResults
                .Include(er => er.Student)
                .Where(er => er.LecturerId == lecturerId && er.ExamId == examId)
                .ToListAsync();
        }

        // Lấy điểm của một sinh viên trong một kỳ thi
        public async Task<ExamResult?> GetStudentExamResultInExamAsync(string studentId, string examId)
        {
            return await _context.ExamResults
                .Include(er => er.Student)
                .Include(er => er.Exam)
                .FirstOrDefaultAsync(er => er.StudentId == studentId && er.ExamId == examId);
        }

        // Kiểm tra giảng viên có thể chấm bài cho môn học đó không
        public async Task<bool> LecturerCanGradeSubjectAsync(string lecturerId, string examId)
        {
            // Lấy subjectId từ ExamId
            var subjectId = await _context.Exams
                .Where(e => e.ExamId == examId)
                .Select(e => e.SubjectId)
                .FirstOrDefaultAsync();

            if (subjectId == null)
            {
                return false; // Không tìm thấy kỳ thi hoặc môn học không hợp lệ
            }

            // Kiểm tra xem giảng viên có dạy môn học này không
            return await _context.LecturerSubjects
                .AnyAsync(ls => ls.LecturerId == lecturerId && ls.SubjectId == subjectId);
        }
        // Cập nhật điểm sinh viên
        public async Task UpdateStudentScoreAsync(string resultId, decimal score)
        {
            var examResult = await GetExamResultByIdAsync(resultId);
            if (examResult != null)
            {
                examResult.Score = score;
                await _context.SaveChangesAsync();
            }
        }
    }
}
