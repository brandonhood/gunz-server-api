using Gunz.Server.Domain.Contracts.Security;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Accounts
{
    public interface IAccountManager
    {
        Task<ApiTokenResponse> GetApiTokenAsync(ApiTokenRequest request);
    }
}
