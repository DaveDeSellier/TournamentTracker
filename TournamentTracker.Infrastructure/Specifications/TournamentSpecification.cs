using TournamentTracker.Core.Models;
using TournamentTracker.Infrastructure.Data;

namespace TournamentTracker.Infrastructure.Specifications
{
    public class TournamentSpecification : BaseSpecification<Tournament>
    {
        public TournamentSpecification(int tournamentId) : base(x => x.Id == tournamentId)
        {
            AddInclude(x => x.TournamentEntries);
            AddInclude(x => x.TournamentPrizes);
            AddInclude("Matchups");
            AddInclude("Matchups.MatchupEntries");
            AddInclude("Matchups.MatchupEntries.TeamCompeting");

        }
    }
}
