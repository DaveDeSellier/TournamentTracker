namespace TournamentTracker.API.Models
{
    public class TournamentEntryResource
    {
        public int Id { get; set; }

        public TeamResource Team { get; set; } = default!;

    }
}
