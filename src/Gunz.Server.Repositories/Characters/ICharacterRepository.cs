using Gunz.Server.Data.Models.Characters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunz.Server.Repositories.Characters
{
    public interface ICharacterRepository
    {
        Task<List<CharacterModel>> GetCharactersForAccountAsync(int accountId);

        Task<CharacterModel> AddCharacterAsync(CharacterModel character);
    }
}
