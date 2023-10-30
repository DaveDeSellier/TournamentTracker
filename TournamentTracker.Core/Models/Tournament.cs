using System.Text.Json.Serialization;
using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class Tournament : BaseModel
{
    public string TournamentName { get; set; } = null!;

    public decimal EntryFee { get; set; }

    [JsonIgnore]
    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    [JsonIgnore]
    public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

    [JsonIgnore]
    public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; } = new List<TournamentPrize>();


}
