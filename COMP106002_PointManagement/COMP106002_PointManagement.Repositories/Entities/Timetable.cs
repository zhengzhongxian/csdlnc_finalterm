using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Timetable
{
    public string TimetableId { get; set; } = null!;

    public string? ClassId { get; set; }

    public string? DayOfWeek { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? RoomId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Room? Room { get; set; }
}
