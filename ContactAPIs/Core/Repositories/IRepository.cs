using System.Linq.Expressions;

namespace ContactAPIs.Core.Repositories
{
    public interface IRepository<T, TId>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
