using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly storeDbContext _context;

        public SearchHistoryRepository(storeDbContext context) 
        {
            _context = context;
        }
        public async Task AddSearchHistoryAsync(string keyword)
        {
            var searchHistory = new SearchHistory
            {
                Keyword = keyword,
                SearchedAt = DateTime.UtcNow
            };
            await _context.SearchHistory.AddAsync(searchHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOldestSearchAsync()
        {
            var oldestSearch = await _context.SearchHistory
            .OrderBy(s => s.SearchedAt)
            .FirstOrDefaultAsync();

            if (oldestSearch != null) 
            {
                _context.SearchHistory.Remove(oldestSearch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SearchHistory>> GetRecentSearchesAsync(int count)
        {
            return await _context.SearchHistory
            .OrderByDescending(s => s.SearchedAt)
            .Take(count)
            .ToListAsync();
        }
    }
}
