using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string? StudentName { get; set; }

    public string? Photo { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Dayofbirth { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? IdEs { get; set; }

    public string? IdAcademicYear { get; set; }

    public string? FacultyId { get; set; }

    public int? LocationId { get; set; }

    public string? AuditableId { get; set; }

    public virtual ICollection<ClassStudent> ClassStudents { get; set; } = new List<ClassStudent>();

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Faculty? Faculty { get; set; }

    public virtual AcademicYear? IdAcademicYearNavigation { get; set; }

    public virtual EducationSystem? IdEsNavigation { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
