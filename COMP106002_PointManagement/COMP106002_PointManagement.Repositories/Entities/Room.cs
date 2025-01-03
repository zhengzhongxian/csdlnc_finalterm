using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Room
{
    public string RoomId { get; set; } = null!;

    public string? RoomName { get; set; }

    public int? Capacity { get; set; }

    public int? LocationId { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
