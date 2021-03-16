using Gunz.Server.Data.Models.Accounts;
using System.Threading.Tasks;

namespace Gunz.Server.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<LoginInfo> GetAccountByCredentialsAsync(string username, string password);
    }
}
