using Gunz.Server.Common.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Gunz.Server.Api.CustomMiddleware
{
    internal class ExceptionMiddleware
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
            catch (Exception ex)
            {
                HandleException(ex, httpContext);
            }
        }

        private void HandleException(Exception ex, HttpContext httpContext)
        {
            switch (ex)
            {
                case CustomAccountAccessException e:
                    _logger.LogError(
                        "User {RequestingAccountId} attempted to access a different account: {TargetAccountId}.",
                        e.RequestingAccountId,
                        e.TargetAccountId
                    );

                    SetForbiddenResponse(httpContext);
                    return;

                case CustomAuthenticationException e:
                    _logger.LogError(
                        "Error occurred during authentication: {Message}",
                        e.Message
                    );

                    SetForbiddenResponse(httpContext);
                    return;

                default:
                    _logger.LogError(ex, "Unexpected exception.");
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return;
            }
        }

        private void SetForbiddenResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }
    }
}
