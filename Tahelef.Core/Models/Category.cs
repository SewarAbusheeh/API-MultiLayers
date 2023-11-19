using System;
using System.Collections.Generic;

namespace Tahelef.Core.Models;

public partial class Category
{
    public decimal Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
