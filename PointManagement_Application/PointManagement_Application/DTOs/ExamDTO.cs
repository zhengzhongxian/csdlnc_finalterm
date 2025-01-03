using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class ExamDTO
    {
        public string ExamId { get; set; }
        public string SubjectName { get; set; }
        public string RoomName { get; set; }
        public DateTime ExamDate { get; set; }
        public string TimeSlot { get; set; }
        public int Duration { get; set; }
        public int VacantSeat { get; set; }
        public string InvigilatorName { get; set; }
        public string ExamType { get; set; }
    }
}
