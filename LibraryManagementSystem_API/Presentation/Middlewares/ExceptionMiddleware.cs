using Business;
using Business.Abstract;
using System.Net;
using System.Text.Json;

namespace Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                using (var scope = _scopeFactory.CreateScope())
                {
                    var _logService = scope.ServiceProvider.GetRequiredService<ILogService>();
                    await _logService.AddAsync(null, ex.ToString());
                }
                    
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new Result<object>
            {
                IsSuccess = false,
                ErrorMessage = "An unexpected error occurred.",
                StatusCode = ResultCodes.ServerError,
                Data = null
            });

            return context.Response.WriteAsync(result);
        }
    }
}
