using System;
using System.Collections.Generic;

namespace Repositories.Models;

public class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
}
