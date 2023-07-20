using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;
using TournamentTracker.Infrastructure.Data;

namespace TournamentTracker.Infrastructure.Services
{
    public class TeamMemberService : Repository<TeamMember>, ITeamMember
    {
        private readonly TournamentTrackerContext _context;
        public TeamMemberService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

    }

}
