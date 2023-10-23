using TournamentTracker.Core.Models;

namespace TournamentTracker.Core.Interfaces
{
    public interface ITournament : IRepository<Tournament>
    {
        Task<Tournament> SaveTournamentRound(Tournament tournament);
        Task InsertTournament(Tournament tournament);
    }
}
