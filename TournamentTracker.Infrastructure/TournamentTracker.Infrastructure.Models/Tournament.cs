using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class Tournament
{
    public int Id { get; set; }

    public string TournamentName { get; set; } = null!;

    public decimal EntryFee { get; set; }

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

    public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();
}
