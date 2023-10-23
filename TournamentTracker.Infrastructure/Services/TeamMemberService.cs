using Microsoft.Extensions.Logging;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TeamMemberService : Repository<TeamMember>, ITeamMember
    {
        private readonly TournamentTrackerContext _context;

        public TeamMemberService(TournamentTrackerContext context, ILogger<TeamMemberService> logger) : base(context, logger)
        {
            _context = context;
        }

    }

}
