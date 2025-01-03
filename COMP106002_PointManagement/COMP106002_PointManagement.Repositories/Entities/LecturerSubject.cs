using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class LecturerSubject
{
    public string Id { get; set; } = null!;

    public string? LecturerId { get; set; }

    public string? SubjectId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Lecturer? Lecturer { get; set; }

    public virtual Subject? Subject { get; set; }
}
