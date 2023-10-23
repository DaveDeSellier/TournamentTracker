using TournamentTracker.Core.Models;

namespace TournamentTracker.UI.ViewModels
{
    public class MatchupVM
    {
        public int Id { get; set; }

        public int? WinnerId { get; set; }

        public int MatchupRound { get; set; }

        public List<MatchupEntryVM> MatchupEntries { get; set; } = new List<MatchupEntryVM>();

        public string DisplayName { get; set; } = string.Empty;

        public MatchupVM()
        {

        }

        public MatchupVM(Matchup matchup)
        {
            Id = matchup.Id;
            WinnerId = matchup.WinnerId;
            MatchupRound = matchup.MatchupRound;
        }
    }
}
