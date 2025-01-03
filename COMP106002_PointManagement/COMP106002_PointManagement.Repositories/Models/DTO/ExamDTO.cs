using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class ExamDTO
    {
        public string ExamId { get; set; }
        public string SubjectName { get; set; }
        public string RoomName { get; set; }
        public DateOnly ExamDate { get; set; }
        public TimeOnly TimeSlot { get; set; }
        public int Duration { get; set; }
        public int VacantSeat { get; set; }
        [JsonIgnore]
        public string? InvigilatorId { get; set; }
        public string InvigilatorName { get; set; }
        public string ExamType { get; set; }
    }
}
