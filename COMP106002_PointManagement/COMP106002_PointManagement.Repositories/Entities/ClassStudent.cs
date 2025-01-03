using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class ClassStudent
{
    public string Id { get; set; } = null!;

    public string? ClassId { get; set; }

    public string? StudentId { get; set; }

    public decimal? Score { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
