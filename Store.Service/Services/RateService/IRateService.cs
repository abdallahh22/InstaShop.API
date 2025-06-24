using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.RateService
{
    public interface IRateService
    {
        Task<RateDto> CreateRateAsync(RateDto RateDto);
        Task<RateDto> UpdateRateAsync(int? id, RateDto RateDto);
        Task<RateDto> DeleteRateAsync(int? Id);
        Task<RateDto> GetRateByIdAsync(int? Id);
        Task<IEnumerable<RateDto>> GetAllRateAsync();
        Task<IEnumerable<RateDto>> GetRatesByUserIdAsync(string userId);
    }
}
