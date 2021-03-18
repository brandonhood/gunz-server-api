using Gunz.Server.Api.Helpers;
using Gunz.Server.Business.Models;
using Gunz.Server.Common.CustomExceptions;
using Gunz.Server.Common.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Gunz.Server.Api.CustomFilters
{
    internal class BearerTokenFilter : Attribute, IAuthorizationFilter
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IDateTimeHelper _dateTimeHelper;

        public BearerTokenFilter(IJwtHelper jwtHelper, IDateTimeHelper dateTimeHelper)
        {
            _jwtHelper = jwtHelper;
            _dateTimeHelper = dateTimeHelper;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var values) || values.Count != 1)
                throw new CustomAuthenticationException("Request did not contain exactly one Authorization header.");
            if (!values[0].StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                throw new CustomAuthenticationException($"Authorization header is malformed: {values[0]}");

            var payload = _jwtHelper.ValidateToken(values[0]["Bearer ".Length..]);
            var now = _dateTimeHelper.GetUtcNow();
            var currentTimestamp = _dateTimeHelper.GetSecondsSinceEpoch(now);

            if (currentTimestamp >= payload.ExpiresAt)
                throw new CustomAuthenticationException("Request contained expired JWT.");

            context.HttpContext.Items["RequestingAccountInfo"] = new RequestingAccountInfo(payload);

            return;
        }
    }
}
