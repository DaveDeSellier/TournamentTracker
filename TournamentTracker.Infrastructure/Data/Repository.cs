using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        private readonly TournamentTrackerContext _context;
        protected readonly ILogger _logger;

        public Repository(TournamentTrackerContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task Add(T entity)
        {
            _logger.LogInformation($"Adding entity");
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not add entity {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        public virtual async Task Delete(T entity)
        {
            _logger.LogInformation($"Deleting entity");
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not delete entity {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        public virtual async Task Edit(T entity)
        {
            _logger.LogInformation($"Updating entity");
            try
            {
                _context.Set<T>().Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not update entity {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        public virtual async Task<T?> GetById(int id)
        {
            _logger.LogInformation($"Retrieving entity by ID");
            T? entity = null;
            try
            {
                entity = await _context.Set<T>().FindAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not retrieve entity {ex.Message} {ex.StackTrace}");
                throw;
            }

            return entity;

        }

        public virtual async Task<List<T>> List()
        {

            _logger.LogInformation("Retrieving list");

            var list = new List<T>();
            try
            {
                list = await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not retrieve list {ex.Message} {ex.StackTrace}");
                throw;
            }

            return list;

        }

        public virtual async Task<List<T>?> List(Expression<Func<T, bool>> predicate)
        {

            _logger.LogInformation("Retrieving list");
            List<T> result = new List<T>();

            try
            {
                result = await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not retrieve list {ex.Message} {ex.StackTrace}");
                throw;
            }

            return result;
        }

        public async Task<List<T>> List(ISpecification<T> spec)
        {

            _logger.LogInformation("Retrieving list");
            List<T> result = new List<T>();
            try
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
                result = await secondaryResult
                                .Where(spec.Criteria)
                                .ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: Could not retrieve list {ex.Message} {ex.StackTrace}");
                throw;
            }

            return result;
        }
    }
}
