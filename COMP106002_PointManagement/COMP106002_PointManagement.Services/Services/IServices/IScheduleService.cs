using COMP106002_PointManagement.Repositories.Models.CU_DTO;
using COMP106002_PointManagement.Repositories.Models.DTO;
using COMP106002_PointManagement.Repositories.Models.Other_DTO;
using COMP106002_PointManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Services.Services.IServices
{
    public interface IScheduleService
    {
        Task<ServiceResponse<IEnumerable<ScheduleDTO>>> GetSchedulesByExamIdAsync(string examId);

        Task<ServiceResponse<bool>> CreateScheduleAsync(ScheduleCreateUpdateDTO scheduleDto);

        Task<ServiceResponse<bool>> UpdateScheduleAsync(string scheduleId, int seatNumber);

        Task<ServiceResponse<bool>> DeleteScheduleAsync(string examId, string studentId);

        Task<ServiceResponse<IEnumerable<int>>> GetOccupiedSeatsAsync(string examId);
        Task<ServiceResponse<IEnumerable<OtherStudentDTO>>> GetStudentsNotInScheduleAsync(string examId);
        Task<ServiceResponse<IEnumerable<int>>> GetAvailableSeatsAsync(string examId);
        Task<ServiceResponse<bool>> UpdateScheduleStatusToTwoAsync(string scheduleId);
    }
}
