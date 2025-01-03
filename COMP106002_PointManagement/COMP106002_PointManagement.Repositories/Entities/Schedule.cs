using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Schedule
{
    public string ScheduleId { get; set; } = null!;

    public string? ExamId { get; set; }

    public string? StudentId { get; set; }

    public int? SeatNumber { get; set; }

    public int? Status { get; set; }

    public virtual Exam? Exam { get; set; }

    public virtual Student? Student { get; set; }
}
