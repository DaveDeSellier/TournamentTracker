using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;

public class TeamMember : BaseModel
{

    public int TeamId { get; set; }

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;


}
