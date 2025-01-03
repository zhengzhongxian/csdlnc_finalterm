using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string? SubjectName { get; set; }

    public int? Credits { get; set; }

    public string? FacultyId { get; set; }

    public int? TypescoreId { get; set; }

    public int? SemesterId { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual Faculty? Faculty { get; set; }

    public virtual ICollection<LecturerSubject> LecturerSubjects { get; set; } = new List<LecturerSubject>();

    public virtual Semester? Semester { get; set; }

    public virtual Typescore? Typescore { get; set; }
}
