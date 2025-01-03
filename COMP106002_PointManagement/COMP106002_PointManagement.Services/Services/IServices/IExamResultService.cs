using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IExamResultService
    {
        Task<ServiceResponse<IEnumerable<ExamResultDTO>>> GetAllExamResultsAsync();
        Task<ServiceResponse<ExamResultDTO>> GetExamResultByIdAsync(string resultId);
        Task<ServiceResponse<bool>> CreateExamResultAsync(ExamResultCU_DTO examResultDto);
        Task<ServiceResponse<bool>> UpdateExamResultAsync(string resultId, string lecturerId);
        Task<ServiceResponse<bool>> DeleteExamResultAsync(string resultId);

        // New methods
        Task<ServiceResponse<IEnumerable<ExamDTO>>> GetExamsByLecturerAsync(string lecturerId);
        Task<ServiceResponse<IEnumerable<ExamResultDTO>>> GetStudentsByLecturerInExamAsync(string lecturerId, string examId);
        Task<ServiceResponse<ExamResultDTO>> GetStudentExamResultInExamAsync(string studentId, string examId);
        Task<ServiceResponse<bool>> UpdateStudentScoreAsync(string resultId, decimal score);
    }
}
