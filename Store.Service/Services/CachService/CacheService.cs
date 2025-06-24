using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Services.Services.CachService
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _database;

        public CacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<string> GetCacheResponseAsync(string Key)
        {
            var cachedresponse = await _database.StringGetAsync(Key);
            if (cachedresponse.IsNullOrEmpty)
                return null;
            return cachedresponse.ToString();
        }

        public async Task SetCacheResponseAsync(string Key, object response, TimeSpan timetolive)
        {
            if (response is null)
                return;
            var serilizedResponse = JsonSerializer.Serialize(response);
            await _database.StringSetAsync(Key, serilizedResponse, timetolive);
        }
    }
}
