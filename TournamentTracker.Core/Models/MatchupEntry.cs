using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class MatchupEntry : BaseModel
{

    public int MatchupId { get; set; }

    public int? ParentMatchupId { get; set; }

    public int? Score { get; set; }

    public int? TeamCompetingId { get; set; }

    public virtual Matchup Matchup { get; set; } = null!;

    public virtual Team? TeamCompeting { get; set; } = null!;
}
