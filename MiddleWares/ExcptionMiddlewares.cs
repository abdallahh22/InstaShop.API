using Store.Services.HandleResponse;
using System.Net;
using System.Text.Json;

namespace Store.API.MiddleWares
{
    public class ExcptionMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ExcptionMiddlewares> _logger;

        public ExcptionMiddlewares(
            RequestDelegate next,
            IHostEnvironment environment,
            ILogger<ExcptionMiddlewares> logger
            )
        {
            _next = next;
            _environment = environment;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _environment.IsDevelopment()
                    ? new CustomExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new CustomExceptions((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
