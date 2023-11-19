using System;
using System.Collections.Generic;

namespace Tahelef.Core.Models;

public partial class Role
{
    public decimal Roleid { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<Login> Logins { get; } = new List<Login>();
}
