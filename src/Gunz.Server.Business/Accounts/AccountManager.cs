using AutoMapper;
using Gunz.Server.Common.CustomExceptions;
using Gunz.Server.Data;
using Gunz.Server.Domain.Contracts.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Accounts
{
    internal class AccountManager : ManagerBase, IAccountManager
    {
        public AccountManager(ILoggerFactory loggerFactory, IMapper mapper, IGunzDatabaseContextFactory gunzDatabaseContextFactory)
            : base(loggerFactory.CreateLogger<AccountManager>(), mapper, gunzDatabaseContextFactory)
        {
        }

        public async Task<ApiTokenResponse> GetApiTokenAsync(ApiTokenRequest request)
        {
            await using var context = _gunzDatabaseContextFactory.CreateContext();
            var match = await context.LoginInfos.FirstOrDefaultAsync(i => i.Username == request.Username && i.Password == request.Password) ??
                throw new CustomAuthenticationException($"User failed to authenticate: {request.Username}");

            return new ApiTokenResponse()
            {
                AccessToken = match.AccountId.ToString(),
                AccountId = match.AccountId
            };
        }
    }
}
