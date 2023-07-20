using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class Team
{
    public int Id { get; set; }

    public string TeamName { get; set; } = null!;

    public virtual ICollection<MatchupEntry> MatchupEntries { get; set; } = new List<MatchupEntry>();

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();
}
