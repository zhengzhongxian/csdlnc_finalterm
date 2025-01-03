using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class ClassStudentDTO
    {
        public string Id { get; set; } = null!;
        public string? ClassId { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? Score { get; set; } 
    }

    public class ClassStudentCreateDTO
    {
        public string? ClassId { get; set; }
        public string? StudentId { get; set; }
    }

    public class ClassStudentUpdateDTO
    {
        public decimal? Score { get; set; }
    }
}
