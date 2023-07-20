using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class Matchup
{
    public int Id { get; set; }

    public int? WinnerId { get; set; }

    public int MatchupRound { get; set; }

    public int TournamentId { get; set; }

    public virtual ICollection<MatchupEntry> MatchupEntries { get; set; } = new List<MatchupEntry>();

    public virtual Tournament Tournament { get; set; } = null!;

    public virtual Team? Winner { get; set; }
}
