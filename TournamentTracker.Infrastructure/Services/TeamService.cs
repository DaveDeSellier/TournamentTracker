using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TeamService : Repository<Team>, ITeam
    {
        private readonly TournamentTrackerContext _context;

        public TeamService(TournamentTrackerContext context, ILogger<TeamService> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams
                    .Include(teams => teams.TeamMembers)
                    .ThenInclude(teamMembers => teamMembers.Person)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Team> AddTeamAsync(Team team)
        {

            await _context.AddAsync(team);

            await _context.SaveChangesAsync();

            return team;

        }


    }

}
