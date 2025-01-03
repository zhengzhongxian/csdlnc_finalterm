using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class ExamResult
{
    public string ResultId { get; set; } = null!;

    public decimal? Score { get; set; }

    public string? LecturerId { get; set; }

    public string? ExamId { get; set; }

    public string? StudentId { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual Lecturer? Lecturer { get; set; }

    public virtual Student? Student { get; set; }
}
