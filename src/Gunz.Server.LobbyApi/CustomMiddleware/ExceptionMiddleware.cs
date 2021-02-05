using Gunz.Server.Api.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Gunz.Server.Api.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) when (ex is CustomAccountAccessException cae)
            {
                _logger.LogError(
                    "User {RequestingAccountId} attempted to access a different account: {TargetAccountId}.",
                    cae.RequestingAccountId,
                    cae.TargetAccountId
                );

                SetForbiddenResponse(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception.");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        private void SetForbiddenResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }
    }
}
