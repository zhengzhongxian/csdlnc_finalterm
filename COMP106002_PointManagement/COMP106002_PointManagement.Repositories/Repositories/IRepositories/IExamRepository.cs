using COMP106002_PointManagement.API;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync(int location_id);
        Task<Exam?> GetExamByIdAsync(string id);
        Task CreateExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(string id);
        Task<bool> IsRoomAvailable(string roomId, DateOnly? examDate, TimeOnly timeSlot, int? duration, string excludeExamId = null);
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly examDate, TimeOnly timeSlot, int duration, int location_id, string excludeExamId = null);
        Task<bool> IsLecturerAvailableAsync(string lecturerId, DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null);
        Task<IEnumerable<Lecturer>> GetAvailableLecturersAsync(DateOnly examDate, TimeOnly timeSlot, int duration, string excludeExamId = null);
        Task<IEnumerable<Exam>> GetExamsByFacultyIdAsync(string facultyId, int location_id);
        Task<IEnumerable<Lecturer>> GetLecturersByExamIdAsync(string examId);
        Task<IEnumerable<Exam>> GetTotalExamsAsync();
    }
}
