using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class MatchupEntryVM
    {
        public int Id { get; set; }

        public int? MatchupId { get; set; }

        public int? ParentMatchupId { get; set; }

        public int? Score { get; set; }

        public int? TeamCompetingId { get; set; }

        public TeamVM TeamCompeting { get; set; } = null!;

        public MatchupVM ParentMatchup { get; set; } = null!;

        public MatchupEntryVM()
        {

        }

        public MatchupEntryVM(MatchupEntry matchup)
        {
            Id = matchup.Id;
            MatchupId = matchup.MatchupId;
            Score = matchup.Score;
            TeamCompetingId = matchup.TeamCompetingId;
            TeamCompeting = matchup.TeamCompeting == null ? null : new TeamVM(matchup.TeamCompeting);
        }

    }

}
