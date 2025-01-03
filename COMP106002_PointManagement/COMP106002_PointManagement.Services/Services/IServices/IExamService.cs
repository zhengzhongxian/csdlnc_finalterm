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
    public interface IExamService
    {
        Task<ServiceResponse<IEnumerable<ExamDTO>>> GetAllExamsAsync(int location_id);
        Task<ServiceResponse<ExamDTO?>> GetExamByIdAsync(string id);
        Task<ServiceResponse<bool>> CreateExamAsync(ExamCreateUpdateDTO examDto, string made_by, int location_id);
        Task<ServiceResponse<bool>> UpdateExamAsync(string id, ExamCreateUpdateDTO examDto, string made_by, int location_id);
        Task<ServiceResponse<bool>> DeleteExamAsync(string id, string made_by, int location_id);
        Task<ServiceResponse<IEnumerable<RoomDTO>>> GetAvailableRoomsAsync(DateOnly examDate, TimeOnly timeSlot, int? duration, int locationid, string excludeExamId = null);
        Task<ServiceResponse<IEnumerable<LecturerDTO>>> GetAvailableLecturersAsync(DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null);
        Task<ServiceResponse<IEnumerable<ExamDTO>>> GetExamsByFacultyIdAsync(string facultyId, int location_id);
        Task<ServiceResponse<IEnumerable<SimplifiedLecturerDTO>>> GetLecturersByExamIdAsync(string examId);
        Task<ServiceResponse<bool>> Transfer(string transfer_by, int location_id);
        Task<ServiceResponse<bool>> Restore(string restore_by, int location_id);
    }
}
