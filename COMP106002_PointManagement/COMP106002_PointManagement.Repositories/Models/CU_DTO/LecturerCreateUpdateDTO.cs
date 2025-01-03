using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.CU_DTO
{
    public class LecturerCreateUpdateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Degree { get; set; }
        public int? YearsOfExperience { get; set; }
        public byte[]? Photo { get; set; }
        public DateOnly? Dob { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}
