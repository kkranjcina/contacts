using ContactAPIs.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactAPIs.Dal.Repositories
{
    public class Repository<T, TId> : IRepository<T, TId>
        where T : class
    {
        protected readonly ContactsDbContext _dbContext;
        protected readonly DbSet<T> _entityDbSet;

        public Repository(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
            _entityDbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entityDbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entityDbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entityDbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
      
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _entityDbSet.FindAsync(id);
        }
    }
}
