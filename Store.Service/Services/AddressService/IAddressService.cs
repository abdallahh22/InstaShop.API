using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.AddressService
{
    public interface IAddressService 
    {
        Task<AddressDto> CreateAddressAsync(AddressDto AddressDto);
        Task<AddressDto> UpdateAddressAsync(int? id, AddressDto AddressDto);
        Task<AddressDto> DeleteAddressAsync(int? PlayerId);
        Task<AddressDto> GetAddressByIdAsync(int? Id);
        Task<IEnumerable<AddressDto>> GetAllAddressAsync();
        Task<List<AddressDto>> GetAddressByUserId(string UserId);
    }
}
