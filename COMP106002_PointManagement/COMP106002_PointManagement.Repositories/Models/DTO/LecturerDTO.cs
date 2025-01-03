using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.DTO
{
    public class LecturerDTO
    {
        public string LecturerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Degree { get; set; }
        public int? YearsOfExperience { get; set; }
        public byte[]? Photo { get; set; }
    }
}
