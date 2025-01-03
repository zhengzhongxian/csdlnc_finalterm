using COMP106002_PointManagement.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IExamResultRepository
    {
        Task<IEnumerable<ExamResult>> GetAllExamResultsAsync();
        Task<ExamResult?> GetExamResultByIdAsync(string resultId);
        Task CreateExamResultAsync(ExamResult examResult);
        Task UpdateExamResultAsync(ExamResult examResult);
        Task DeleteExamResultAsync(string resultId);

        // New methods
        Task<IEnumerable<Exam>> GetExamsByLecturerAsync(string lecturerId);
        Task<IEnumerable<ExamResult>> GetStudentsByLecturerInExamAsync(string lecturerId, string examId);
        Task<ExamResult?> GetStudentExamResultInExamAsync(string studentId, string examId);
        Task<bool> LecturerCanGradeSubjectAsync(string lecturerId, string examId);
        Task UpdateStudentScoreAsync(string resultId, decimal score);
    }
}
