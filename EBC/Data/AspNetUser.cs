using System;
using System.Collections.Generic;

namespace EBC;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public long AccessFailedCount { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? Email { get; set; }

    public long EmailConfirmed { get; set; }

    public long LockoutEnabled { get; set; }

    public string? LockoutEnd { get; set; }

    public string? NormalizedEmail { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public long PhoneNumberConfirmed { get; set; }

    public string? SecurityStamp { get; set; }

    public long TwoFactorEnabled { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
