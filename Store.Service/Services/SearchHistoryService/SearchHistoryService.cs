using AutoMapper;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.SearchHistoryService
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddSearchHistoryAsync(string keyword)
        {
            await _unitOfWork.SearchHistories.AddSearchHistoryAsync(keyword);

            var recentSearches = await _unitOfWork.SearchHistories.GetRecentSearchesAsync(4);
            var totalSearchCount = await _unitOfWork.SearchHistories.GetRecentSearchesAsync(int.MaxValue);

            if (totalSearchCount.Count() > 4)
            {
                await _unitOfWork.SearchHistories.DeleteOldestSearchAsync();
            }
        }

        public async Task DeleteOldestSearchAsync()
        {
           await _unitOfWork.SearchHistories.DeleteOldestSearchAsync();

        }

        public async Task<IEnumerable<SearchHistoryDto>> GetRecentSearchesAsync(int count)
        {
            var recentSearches = await _unitOfWork.SearchHistories.GetRecentSearchesAsync(count);
            return recentSearches.Select(s => new SearchHistoryDto
            {
                
                Keyword = s.Keyword,
                SearchedAt = s.SearchedAt
            }).ToList();
        }
    }
}
