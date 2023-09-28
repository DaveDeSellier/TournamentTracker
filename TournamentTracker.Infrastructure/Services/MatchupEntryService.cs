using Microsoft.Extensions.Logging;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class MatchupEntryService : Repository<MatchupEntry>, IMatchUpEntry
    {
        private readonly TournamentTrackerContext _context;
        public MatchupEntryService(TournamentTrackerContext context, ILogger<MatchupEntryService> logger) : base(context, logger)
        {
            _context = context;

        }

    }
}
