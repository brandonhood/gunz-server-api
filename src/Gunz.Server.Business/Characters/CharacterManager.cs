using AutoMapper;
using Gunz.Server.Business.Models;
using Gunz.Server.Data;
using Gunz.Server.Domain.Contracts.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunz.Server.Business.Characters
{
    internal class CharacterManager : ManagerBase, ICharacterManager
    {
        #region Constructors

        public CharacterManager(ILoggerFactory loggerFactory, IMapper mapper, IGunzDatabaseContextFactory gunzDatabaseContextFactory)
            : base(loggerFactory.CreateLogger<CharacterManager>(), mapper, gunzDatabaseContextFactory)
        {
        }

        #endregion

        #region ICharacterRepository

        public async Task<List<Character>> GetCharactersForAccountAsync(int accountId, RequestingAccountInfo requestingAccountInfo)
        {
            CheckAccountAccess(accountId, requestingAccountInfo);

            await using var context = _gunzDatabaseContextFactory.CreateContext();
            var models = await context.Characters
                .Where(c => c.AccountId == accountId)
                .OrderBy(c => c.Order)
                .ToListAsync();

            return _mapper.Map<List<Character>>(models);
        }

        #endregion
    }
}
