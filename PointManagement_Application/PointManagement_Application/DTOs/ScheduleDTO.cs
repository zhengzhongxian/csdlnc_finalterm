using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class ScheduleDTO
    {
        public string ScheduleId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public int SeatNumber { get; set; }
        public int Status { get; set; }
        public string LecturerId { get; set; }
        public decimal? Score { get; set; }
        public string LecturerName { get; set; }
        public string ResultId { get; set; }
        public string EmailLecturer {  get; set; }
    }
}
