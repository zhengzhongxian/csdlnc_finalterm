using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class ExamResultDTO
    {
        public string ResultId { get; set; } = null!;
        public decimal? Score { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? ExamId { get; set; }
        public string? ExamName { get; set; }
        public string? LecturerName { get; set; }
    }
}
