using Gunz.Server.Business.Models;
using Gunz.Server.Domain.Contracts.Characters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Characters
{
    public interface ICharacterManager
    {
        Task<List<Character>> GetCharactersForAccountAsync(int accountId, RequestingAccountInfo requestingAccountInfo);
    }
}
