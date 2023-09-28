using Microsoft.Extensions.Logging;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure.Services
{
    public class PersonService : Repository<Person>, IPerson
    {
        private readonly TournamentTrackerContext _context;
        public PersonService(TournamentTrackerContext context, ILogger<PersonService> logger) : base(context, logger)
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
