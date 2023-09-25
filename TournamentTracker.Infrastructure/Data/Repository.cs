using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        private readonly TournamentTrackerContext _context;


        public Repository(TournamentTrackerContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Edit(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null) return null;

            return entity;

        }

        public virtual async Task<List<T>> List()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<T>?> List(Expression<Func<T, bool>> predicate)
        {
            List<T> result = new List<T>();

            result = await _context.Set<T>().Where(predicate).ToListAsync();

            return result;
        }

        public async Task<List<T>> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }
    }
}
