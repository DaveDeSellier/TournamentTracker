using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class MatchupEntryService : Repository<MatchupEntry>, IMatchupEntry
    {
        private readonly TournamentTrackerContext _context;
        public MatchupEntryService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

    }
}
