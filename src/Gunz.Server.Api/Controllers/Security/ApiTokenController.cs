using Gunz.Server.Api.CustomExceptions;
using Gunz.Server.Data;
using Gunz.Server.Domain.Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(i => i.Username == request.Username && i.Password == request.Password) ??
                throw new CustomAuthenticationException($"User failed to authenticate: {request.Username}");

            return new ApiTokenResponse()
            {
                AccessToken = match.AccountId.ToString(),   // TODO: JWT
                AccountId = match.AccountId
            };
        }

    }
}
