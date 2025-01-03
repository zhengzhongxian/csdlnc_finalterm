using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class AcademicYear
{
    public string IdAcademicYear { get; set; } = null!;

    public string? YearAcademicYear { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
