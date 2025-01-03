using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application
{
    public class ScheduleCreateUpdateDTO
    {
        public string ExamId { get; set; }
        public string StudentId { get; set; }
        public int SeatNumber { get; set; }
    }
}
