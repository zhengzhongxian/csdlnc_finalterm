using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Class
{
    public string ClassId { get; set; } = null!;

    public string? ClassName { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? IdEs { get; set; }

    public string? IdLectuerSubject { get; set; }

    public int? LocationId { get; set; }

    public string? AuditableId { get; set; }

    public virtual ICollection<ClassStudent> ClassStudents { get; set; } = new List<ClassStudent>();

    public virtual EducationSystem? IdEsNavigation { get; set; }

    public virtual LecturerSubject? IdLectuerSubjectNavigation { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
