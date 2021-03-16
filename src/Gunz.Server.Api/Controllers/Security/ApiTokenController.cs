using Gunz.Server.Business.Accounts;
using Gunz.Server.Domain.Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gunz.Server.Api.Controllers.Security
{
    [Route("api/apitoken")]
    public class ApiTokenController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public ApiTokenController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiTokenResponse> RequestApiToken([FromBody] ApiTokenRequest request)
            => await _accountManager.GetApiTokenAsync(request);
    }
}
