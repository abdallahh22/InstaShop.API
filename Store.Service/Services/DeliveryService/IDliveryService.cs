using Store.Data.Entities;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.DeliveryService
{
    public interface IDliveryService
    {
        Task<DriverDto> CreateDriverAsync(DriverDto DriverDto);
        Task<DriverDto> UpdateDriverAsync(int? id, DriverDto DriverDto);
        Task<DriverDto> DeleteDriverAsync(int? Id);
        Task<DriverDto> GetDriverByIdAsync(int? Id);
        Task<IEnumerable<DriverDto>> GetAllDriverAsync();
    }
}
