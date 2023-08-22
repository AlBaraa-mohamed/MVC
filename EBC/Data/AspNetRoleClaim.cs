using System;
using System.Collections.Generic;

namespace EBC;

public partial class AspNetRoleClaim
{
    public long Id { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public string RoleId { get; set; } = null!;

    public virtual AspNetRole Role { get; set; } = null!;
}
