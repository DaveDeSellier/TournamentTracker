using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class Tournament : BaseModel
{
    public string TournamentName { get; set; } = null!;

    public decimal EntryFee { get; set; }

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

    public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();


}
