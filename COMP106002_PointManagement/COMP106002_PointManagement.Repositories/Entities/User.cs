using System;
using System.Collections.Generic;

namespace COMP106002_PointManagement.API;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public byte[]? Photo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastAccessed { get; set; }

    public string? PhoneNumber { get; set; }

    public int? LocationId { get; set; }

    public virtual Lecturer? Lecturer { get; set; }

    public virtual Location? Location { get; set; }
}
