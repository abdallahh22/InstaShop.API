using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.DashBoradService
{
    public interface IDashBoardService
    {
        Task<DashBoradDto> GetDashboardDataAsync();
    }
}
