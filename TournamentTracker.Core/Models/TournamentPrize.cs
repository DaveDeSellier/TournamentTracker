using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public partial class TournamentPrize : BaseModel
{

    public int TournamentId { get; set; }

    public int PrizeId { get; set; }

    public virtual Prize Prize { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;
}
