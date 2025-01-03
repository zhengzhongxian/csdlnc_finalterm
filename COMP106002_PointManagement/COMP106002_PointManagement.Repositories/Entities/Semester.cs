using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Semester
{
    public int SemesterId { get; set; }

    public string? SemesterName { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
