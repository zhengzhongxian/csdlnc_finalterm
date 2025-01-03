using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class StudentScoreDTO
    {
        public string SubjectName { get; set; }
        public decimal? ClassScore { get; set; }
        public decimal? ExamScore { get; set; }
        public decimal? ScoreSystem10 { get; set; }
        public decimal? ScoreSystem4 { get; set; }
    }
}
