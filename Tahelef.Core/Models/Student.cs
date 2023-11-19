using System;
using System.Collections.Generic;

namespace Tahelef.Core.Models;

public partial class Student
{
    public decimal Studentid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public virtual ICollection<Login> Logins { get; } = new List<Login>();

    public virtual ICollection<Stdcourse> Stdcourses { get; } = new List<Stdcourse>();
}
