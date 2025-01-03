using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Lecturer
{
    public string LecturerId { get; set; } = null!;

    public string? Degree { get; set; }

    public int? YearsOfExperience { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual User LecturerNavigation { get; set; } = null!;

    public virtual ICollection<LecturerSubject> LecturerSubjects { get; set; } = new List<LecturerSubject>();
}
