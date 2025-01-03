using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class LecturerSubjectDTO
    {
        public string Id { get; set; } = null!;
        public string? LecturerId { get; set; }
        public string? LecturerName { get; set; }
        public string? SubjectId { get; set; }
    }

    public class LecturerSubjectCreateDTO
    {
        public string? LecturerId { get; set; }
        public string? SubjectId { get; set; }
    }

    public class LecturerSubjectUpdateDTO
    {
        //public string Id { get; set; } = null!;
        public string? LecturerId { get; set; }
        public string? SubjectId { get; set; }
    }
}
