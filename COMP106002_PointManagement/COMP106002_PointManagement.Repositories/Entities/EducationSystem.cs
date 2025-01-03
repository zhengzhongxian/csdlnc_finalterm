using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class EducationSystem
{
    public string IdEs { get; set; } = null!;

    public string? NameEs { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
