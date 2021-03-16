using AutoMapper;
using Gunz.Server.Business.Models;
using Gunz.Server.Domain.Contracts.Characters;
using Gunz.Server.Repositories.Characters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Characters
{
    internal class CharacterManager : ManagerBase, ICharacterManager
    {
        #region Fields

        private readonly ICharacterRepository _characterRepository;

        #endregion

        #region Constructors

        public CharacterManager(ICharacterRepository characterRepository, ILoggerFactory loggerFactory, IMapper mapper)
            : base(loggerFactory.CreateLogger<CharacterManager>(), mapper)
        {
            _characterRepository = characterRepository;
        }

        #endregion

        #region ICharacterRepository

        public async Task<List<Character>> GetCharactersForAccountAsync(int accountId, RequestingAccountInfo requestingAccountInfo)
        {
            CheckAccountAccess(accountId, requestingAccountInfo);

            var models = await _characterRepository.GetCharactersForAccountAsync(accountId);
            return _mapper.Map<List<Character>>(models);
        }

        #endregion
    }
}
