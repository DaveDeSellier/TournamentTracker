using System;
using System.Collections.Generic;

namespace TournamentTracker.Infrastructure.TournamentTracker.Infrastructure.Models;

public partial class Prize
{
    public int Id { get; set; }

    public int PlaceNumber { get; set; }

    public string PlaceName { get; set; } = null!;

    public decimal PrizeAmount { get; set; }

    public double PrizePercentage { get; set; }

    public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();
}
