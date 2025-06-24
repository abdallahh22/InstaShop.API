using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task<IEnumerable<SearchHistory>> GetRecentSearchesAsync(int count);
        Task AddSearchHistoryAsync(string keyword);
        Task DeleteOldestSearchAsync();
    }
}
