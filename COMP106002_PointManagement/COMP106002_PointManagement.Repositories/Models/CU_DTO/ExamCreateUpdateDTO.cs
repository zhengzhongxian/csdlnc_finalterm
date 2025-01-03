using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.CU_DTO
{
    public class ExamCreateUpdateDTO
    {
        public string SubjectId { get; set; }
        public string RoomId { get; set; }
        public DateOnly ExamDate { get; set; }
        public TimeOnly TimeSlot { get; set; }
        public int Duration { get; set; }
        public string? InvigilatorId { get; set; }
        public string ExamType { get; set; }
    }

}
