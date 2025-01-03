using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    public string? Address { get; set; }

    public string? MongoDbName { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
