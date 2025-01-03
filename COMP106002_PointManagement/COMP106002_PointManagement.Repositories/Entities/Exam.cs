using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Exam
{
    public string ExamId { get; set; } = null!;

    public string? SubjectId { get; set; }

    public string? ExamType { get; set; }

    public DateOnly? ExamDate { get; set; }

    public TimeOnly? TimeSlot { get; set; }

    public int? Duration { get; set; }

    public string? InvigilatorId { get; set; }

    public int? VacantSeat { get; set; }

    public string? RoomId { get; set; }

    public string? AuditableId { get; set; }

    public int? LocationId { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Lecturer? Invigilator { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Subject? Subject { get; set; }
}
