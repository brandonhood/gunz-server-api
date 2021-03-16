using Gunz.Server.Common.CustomExceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Gunz.Server.Api.CustomFilters
{
    public class BearerTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var values) || values.Count != 1)
                throw new CustomAuthenticationException("Request did not contain exactly one Authorization header.");
            if (!values[0].StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                throw new CustomAuthenticationException($"Authorization header is malformed: {values[0]}");

            context.HttpContext.Items["AccountId"] = Convert.ToInt32(values[0]["Bearer ".Length..]);
        }
    }
}
