using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class StudentCreateDTO
    {
        public string StudentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DayOfBirth { get; set; }
        public string Address { get; set; }
        public string FacultyId { get; set; }  // ID của Khoa (Faculty)
        public string IdEs { get; set; }       // ID của Hệ Giáo Dục (Education System)
        public string IdAcademicYear { get; set; }  // ID của Năm Học (Academic Year)
        public byte[] ImageFile { get; set; }
    }
}
