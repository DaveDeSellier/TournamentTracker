namespace TournamentTracker.API.Models
{
    public class MatchupEntryResource
    {
        public int MatchupId { get; set; }

        public int? ParentMatchupId { get; set; }

        public int? Score { get; set; }

        public int? TeamCompetingId { get; set; }

    }
}
