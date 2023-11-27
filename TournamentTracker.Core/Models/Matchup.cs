using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class Matchup : BaseModel
{

    public int? WinnerId { get; set; }

    public int MatchupRound { get; set; }

    public int TournamentId { get; set; }

    public virtual List<MatchupEntry> MatchupEntries { get; set; } = new List<MatchupEntry>();

    public virtual Tournament Tournament { get; set; } = null!;

    public virtual Team? Winner { get; set; }
}
