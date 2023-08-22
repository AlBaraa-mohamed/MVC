using System;
using System.Collections.Generic;

namespace EBC;

public partial class AspNetUserClaim
{
    public long Id { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public string UserId { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
