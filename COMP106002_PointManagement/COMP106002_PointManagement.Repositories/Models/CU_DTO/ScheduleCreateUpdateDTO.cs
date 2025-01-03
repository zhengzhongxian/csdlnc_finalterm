using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.CU_DTO
{
    public class ScheduleCreateUpdateDTO
    {
        public string ExamId { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public int SeatNumber { get; set; }
    }
}
