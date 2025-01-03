using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Faculty
{
    public string FacultyId { get; set; } = null!;

    public string? FacultyName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
