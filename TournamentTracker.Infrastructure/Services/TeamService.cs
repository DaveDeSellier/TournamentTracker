using Microsoft.EntityFrameworkCore;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TeamService : Repository<Team>, ITeam
    {
        private readonly TournamentTrackerContext _context;
        public TeamService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Team>> GetAllTeams()
        {
            return _context.Teams
                    .Include(teams => teams.TeamMembers)
                    .ThenInclude(teamMembers => teamMembers.Person)
                    .ToListAsync();
        }


    }

}
