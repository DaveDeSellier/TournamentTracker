using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class Prize : BaseModel
{

    public int PlaceNumber { get; set; }

    public string PlaceName { get; set; } = null!;

    public decimal PrizeAmount { get; set; }

    public double PrizePercentage { get; set; }

    public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();
}
