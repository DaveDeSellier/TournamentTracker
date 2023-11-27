namespace TournamentTracker.API.Models
{
    public class TeamResource
    {
        public int Id { get; set; }

        public string TeamName { get; set; } = null!;
        public ICollection<TeamMemberResource>? TeamMembers { get; set; } = new List<TeamMemberResource>();
    }
}
