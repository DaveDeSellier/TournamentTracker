using System.Linq.Expressions;
using TournamentTracker.Core.Models.Abstract;

namespace TournamentTracker.Core.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Edit(T entity);
        Task<T?> GetById(int id);
        Task<List<T>> List();
        Task<List<T>?> List(Expression<Func<T, bool>> predicate);
        Task<List<T>> List(ISpecification<T> spec);
    }
}
