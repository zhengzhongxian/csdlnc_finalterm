using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class StudentDTO
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Address { get; set; }
        public string AcademicYearName { get; set; }
        public string EducationSystemName { get; set; }
        public string FacultyName { get; set; }
        public string Photo {  get; set; }
        public string AuditableId { get; set; }
    }
}
