using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class TournamentEntry
{
    public int Id { get; set; }

    public int TournamentId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;
}
