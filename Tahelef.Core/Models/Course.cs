using System;
using System.Collections.Generic;

namespace Tahelef.Core.Models;

public  class Course
{
    public decimal Courseid { get; set; }

    public string? Coursename { get; set; }

    public decimal? Categoryid { get; set; }

    public string? Imagename { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Stdcourse> Stdcourses { get; } = new List<Stdcourse>();
}
