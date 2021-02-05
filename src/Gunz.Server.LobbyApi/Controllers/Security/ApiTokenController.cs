using Gunz.Server.Data;
using Gunz.Server.Domain.Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace Gunz.Server.Api.Controllers.Security
{
    [Route("api/apitoken")]
    public class ApiTokenController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiTokenResponse> RequestApiToken([FromBody] ApiTokenRequest request)
        {
            using var context = new GunzDatabaseContext();
            var match = await context.LoginInfos
                .FirstOrDefaultAsync(i => i.Username == request.Username && i.Password == request.Password);

            if (match == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }

            return new ApiTokenResponse()
            {
                AccessToken = match.AccountId.ToString(),   // TODO: JWT
                AccountId = match.AccountId
            };
        }

    }
}
