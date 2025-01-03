using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class ScheduleDTO
    {
        public string ScheduleId { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public int SeatNumber { get; set; }
        public int Status { get; set; }
        public string? LecturerId { get; set; }
        public string? ResultId { get; set; }
        public decimal? Score { get; set; } 
        public string? LecturerName { get; set; }
    }
}
