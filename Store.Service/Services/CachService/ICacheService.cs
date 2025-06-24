using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.CachService
{
    public interface ICacheService
    {
        Task SetCacheResponseAsync(string Key, object response, TimeSpan timetolive);
        Task<string> GetCacheResponseAsync(string Key); 
    }
}
