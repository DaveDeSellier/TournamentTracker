namespace TournamentTracker.API.Models
{
    public class MatchupResource
    {
        public int Id { get; set; }

        public int? WinnerId { get; set; }

        public int MatchupRound { get; set; }

        public int TournamentId { get; set; }

    }
}
