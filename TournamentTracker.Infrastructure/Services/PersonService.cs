using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class PersonService : Repository<Person>, IPerson
    {
        private readonly TournamentTrackerContext _context;
        public PersonService(TournamentTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;

        }
    }
}
