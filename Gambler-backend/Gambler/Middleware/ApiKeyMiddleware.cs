namespace Gambler.PoC.Middleware
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Threading.Tasks;

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "X-API-Key";

        private readonly ILogger<ApiKeyMiddleware> _logger;

        public ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(context.Request.Path);

            var endpoint = context.GetEndpoint();
            var isAllowAnonymous = endpoint?.Metadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));

            if (isAllowAnonymous == true)
            {
                _logger.LogInformation("AllowAnonymousAttribute");

                await _next(context);
                return;
            }

            if (!context.Request.Path.Equals(@"/api/Gamble/Register"))
            {
                if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");
                    _logger.LogWarning("Api Key was not provided.");
                    return;
                }
                var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
                var apiKey = appSettings.GetValue<string>(APIKEYNAME);

                if (apiKey.IsNullOrEmpty() || !apiKey.Equals(extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");

                    _logger.LogWarning("Unauthorized client.");
                    return;
                }

            }

            await _next(context);
        }
    }
}

