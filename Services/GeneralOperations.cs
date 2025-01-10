using BlogSystemAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class GeneralOperations<T>(DbContext dbContext) : IGeneralOperations<T> where T : class
    {
        private readonly DbContext _dbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}