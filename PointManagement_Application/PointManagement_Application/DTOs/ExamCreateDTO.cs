using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class ExamCreateDTO
    {
        public string SubjectId { get; set; }
        public string RoomId { get; set; }
        public string ExamDate { get; set; }  // Định dạng ngày: "yyyy-MM-dd"
        public string TimeSlot { get; set; }  // Định dạng giờ phút giây: "HH:mm:ss"
        public int Duration { get; set; }
        public string InvigilatorId { get; set; }
        public string ExamType { get; set; }
    }
}
