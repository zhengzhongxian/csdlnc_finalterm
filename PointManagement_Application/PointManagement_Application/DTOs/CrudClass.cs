using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointManagement_Application.DTOs
{
    public class ClassDTO
    {
        public string ClassId { get; set; } 
        public string ClassName { get; set; }
        public int? Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IdEs { get; set; }
        public string EsName { get; set; }
        public string IdLectuerSubject { get; set; }
        public string LecturerName { get; set; }
        public string LecturerId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectId { get; set; }
    }

    public class ClassCreateDTO
    {
        // public string? ClassName { get; set; }
        // public int? Quantity { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IdEs { get; set; }
        public string IdLectuerSubject { get; set; }
    }

    public class ClassUpdateDTO
    {
        //  public string ClassId { get; set; } = null!;
        //  public string? ClassName { get; set; }
        // public int? Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IdEs { get; set; }
        public string IdLectuerSubject { get; set; }
    }
}
