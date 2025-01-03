using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Repositories.IRepositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByExamIdAsync(string examId);

        Task CreateScheduleAsync(ScheduleCreateUpdateDTO scheduleDto);

        Task UpdateScheduleAsync(string scheduleId, int seatNumber);

        Task DeleteScheduleAsync(string examId, string studentId);

        Task<bool> IsStudentEnrolledInSubject(string studentId, string subjectId);

        Task<IEnumerable<int>> GetOccupiedSeatsAsync(string examId);

        Task UpdateVacantSeatAsync(string roomId, bool increase);

        Task<bool> IsSeatOccupiedAsync(string examId, int seatNumber);
        Task<IEnumerable<OtherStudentDTO>> GetStudentsNotInScheduleAsync(string examId);
        Task<int> GetRoomCapacityAsync(string examId);
        Task<IEnumerable<int>> GetAvailableSeatsAsync(string examId);
        Task UpdateScheduleStatusToTwoAsync(string scheduleId);
    }
}
