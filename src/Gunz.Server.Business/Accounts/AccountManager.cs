using Gunz.Server.Common.CustomExceptions;
using Gunz.Server.Domain.Contracts.Security;
using Gunz.Server.Repositories.Accounts;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Accounts
{
    internal class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ApiTokenResponse> GetApiTokenAsync(ApiTokenRequest request)
        {
            var match = await _accountRepository.GetAccountByCredentialsAsync(request.Username, request.Password) ??
                throw new CustomAuthenticationException($"User failed to authenticate: {request.Username}");

            return new ApiTokenResponse()
            {
                AccessToken = match.AccountId.ToString(),
                AccountId = match.AccountId
            };
        }
    }
}
