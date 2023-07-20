using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class MatchupService : Repository<Matchup>, IMatchup
    {
        private readonly TournamentTrackerContext _context;
        public MatchupService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Matchup> AddMatchupAndReturnId(Matchup match)
        {
            _context.Add(match);
            await _context.SaveChangesAsync();

            return match;
        }
    }
}
