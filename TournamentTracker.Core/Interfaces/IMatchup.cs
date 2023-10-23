using TournamentTracker.Core.Models;

namespace TournamentTracker.Core.Interfaces
{
    public interface IMatchup : IRepository<Matchup>
    {
        Task<Matchup> AddMatchupAndReturnId(Matchup match);
    }
}
