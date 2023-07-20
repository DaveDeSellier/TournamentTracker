using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class TournamentService : Repository<Tournament>, ITournament
    {
        private readonly TournamentTrackerContext _context;
        public TournamentService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tournament> SaveTournamentRound(Tournament tournament)
        {
            _context.Add(tournament);
            await _context.SaveChangesAsync();

            return tournament;
        }


    }
}
