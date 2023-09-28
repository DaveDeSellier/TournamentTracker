using Microsoft.Extensions.Logging;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class PrizeService : Repository<Prize>, IPrize
    {
        private readonly TournamentTrackerContext _context;
        public PrizeService(TournamentTrackerContext context, ILogger<PrizeService> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<Prize> AddAndReturnPrize(Prize entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
