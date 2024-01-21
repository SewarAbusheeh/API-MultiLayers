using System;
using System.Collections.Generic;

namespace Tahelef.Core.Models;

public  class Category
{
    public decimal Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
