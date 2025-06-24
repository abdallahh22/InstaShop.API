using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.SearchHistoryService
{
    public interface ISearchHistoryService
    {
        Task<IEnumerable<SearchHistoryDto>> GetRecentSearchesAsync(int count);
        Task AddSearchHistoryAsync(string keyword);
        Task DeleteOldestSearchAsync();
    }
}
