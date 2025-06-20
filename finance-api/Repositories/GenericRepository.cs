using finance_api.Data;
using finance_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace finance_api.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly FinanceDbContext _context;
        private readonly DbSet<T> _dbSet;
        // Generic repository constructor that accepts a FinanceDbContext instance
        public GenericRepository(FinanceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            // Adds a new entity of type T to the database asynchronously
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }       
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Returns all entities of type T from the database
        public async Task<IEnumerable<T>> GetAllAsync() 
            => await _dbSet.ToListAsync();
        

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
