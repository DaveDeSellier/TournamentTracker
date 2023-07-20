using TournamentTracker.Core.Models;

namespace TournamentTracker.Core.Interfaces
{
    public interface IPrize : IRepository<Prize>
    {

        Task<Prize> AddAndReturnPrize(Prize entity);

    }
}
