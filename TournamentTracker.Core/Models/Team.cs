using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Models;


public class Team : BaseModel
{

    public string TeamName { get; set; } = null!;

    public virtual ICollection<MatchupEntry> MatchupEntries { get; set; } = new List<MatchupEntry>();

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public virtual ICollection<TournamentEntry> TournamentEntries { get; set; } = new List<TournamentEntry>();

}
