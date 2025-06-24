using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repository.Interfaces;
using System.Linq.Expressions;

namespace Store.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly storeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(storeDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                   ? await _dbSet.CountAsync()
                   : await _dbSet.CountAsync(predicate);
        }

        public async Task<decimal> SumAsync(Expression<Func<T, decimal>> selector)
        {
            return await _dbSet.SumAsync(selector);
        }

        public async Task<IEnumerable<T>> GetTopAsync<Tkey>(Expression<Func<T, Tkey>> orderBy, int count)
        {
            return await _context.Set<T>().OrderByDescending(orderBy).Take(count).ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
