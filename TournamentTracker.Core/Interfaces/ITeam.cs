using TournamentTracker.Core.Models;

namespace TournamentTracker.Core.Interfaces
{
    public interface ITeam : IRepository<Team>
    {
        Task<List<Team>> GetAllTeams();

        Task<Team> AddTeamAsync(Team team);
    }
}
