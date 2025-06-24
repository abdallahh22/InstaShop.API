using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OfferService
{
    public interface IOfferService
    {
        Task<OfferDto> CreateOfferAsync(OfferDto OfferDto);
        Task<OfferDto> UpdateOfferAsync(int? id, OfferDto OfferDto);
        Task<OfferDto> DeleteOfferAsync(int? Id);
        Task<OfferDto> GetOfferByIdAsync(int? Id);
        Task<IEnumerable<OfferDto>> GetAllOfferAsync();
    }
}
