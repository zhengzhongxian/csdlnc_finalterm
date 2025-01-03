using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Typescore
{
    public int TypesocreId { get; set; }

    public int? ProcessScore { get; set; }

    public int? EndScore { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
