using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class MatchupEntryService : Repository<MatchupEntry>
    {
        private readonly TournamentTrackerContext _context;
        public MatchupEntryService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

    }
}
