namespace TournamentTracker.API.Models
{
    public class TeamMemberResource
    {
        public TeamResource Team { get; set; } = default!;
        public PersonResource Person { get; set; } = default!;

    }
}
