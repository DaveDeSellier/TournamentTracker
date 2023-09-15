using TournamentTracker.Core.Models;

namespace TournamentTracker.Core.Interfaces
{
    public interface IPerson : IRepository<Person>
    {
        Task<Person> CreateAsync(Person person);
    }
}
