using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class MatchupEntry
{
    public int Id { get; set; }

    public int MatchupId { get; set; }

    public int? ParentMatchupId { get; set; }

    public int? Score { get; set; }

    public int? TeamCompetingId { get; set; }

    public virtual Matchup Matchup { get; set; } = null!;

    public virtual Team? TeamCompeting { get; set; }
}
