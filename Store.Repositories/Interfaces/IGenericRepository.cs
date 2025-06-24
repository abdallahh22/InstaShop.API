using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? Id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task<decimal> SumAsync(Expression<Func<T, decimal>> selector);
        Task<IEnumerable<T>> GetTopAsync<Tkey>(Expression<Func<T, Tkey>> orderBy, int count);
        IQueryable<T> GetAll();

    }
}
