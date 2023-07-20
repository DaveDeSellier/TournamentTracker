using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class TournamentEntry : BaseModel
{

    public int TournamentId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;
}
