using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Gunz.Server.LobbyApi.CustomFilters
{
    public class BearerTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var values) ||
                values.Count != 1 ||
                !values[0].StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            context.HttpContext.Items["AccountId"] = Convert.ToInt32(values[0]["Bearer".Length..]);
        }
    }
}
