using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Services.Services.CachService;
using System.Text;

namespace Store.API.Helpers
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToliveinMins;

        public CacheAttribute(int timeToliveinMins)
        {
            _timeToliveinMins = timeToliveinMins;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cachService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cachKey = GenerateCachKeyFromRequest(context.HttpContext.Request);
            var cachResponse = await _cachService.GetCacheResponseAsync(cachKey);

            if (!string.IsNullOrEmpty(cachResponse))
            {
                var conetentResult = new ContentResult
                {
                    Content = cachResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = conetentResult;
                return;
            }

            var excutedContext = await next();
            if (excutedContext.Result is OkObjectResult response)
                await _cachService.SetCacheResponseAsync(cachKey, response.Value, TimeSpan.FromMinutes(_timeToliveinMins));
        }

        private string GenerateCachKeyFromRequest(HttpRequest request)
        {
            StringBuilder cachKey = new StringBuilder();

            cachKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                cachKey.Append($"|{key}-{value}");
            return cachKey.ToString();
                
            
        }
    }
}
