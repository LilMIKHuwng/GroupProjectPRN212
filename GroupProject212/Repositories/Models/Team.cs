using System;
using System.Collections.Generic;

namespace Repositories.Models;

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Match> MatchTeamAs { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchTeamBs { get; set; } = new List<Match>();
}
