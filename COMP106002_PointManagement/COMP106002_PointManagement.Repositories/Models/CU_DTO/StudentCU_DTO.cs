using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP106002_PointManagement.Repositories.Models.CU_DTO
{
    public class StudentCU_DTO
    {
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateOnly? Dayofbirth { get; set; }
        public string? Address { get; set; }
        public string? IdEs { get; set; }
        public string? IdAcademicYear { get; set; }
        public string? FacultyId { get; set; }
        public byte[]? ImageFile {  get; set; }
        //public int? LocationId {  get; set; }
    }
}
