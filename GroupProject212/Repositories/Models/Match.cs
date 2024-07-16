using System;
using System.Collections.Generic;

namespace Repositories.Models;

public class Match
{
    public int Id { get; set; }

    public int? TeamAid { get; set; }

    public int? TeamBid { get; set; }

    public int? LocationId { get; set; }

    public string? Attendance { get; set; }

    public int? GoalTeamA { get; set; }

    public int? GoalTeamB { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Team? TeamA { get; set; }

    public virtual Team? TeamB { get; set; }
}
