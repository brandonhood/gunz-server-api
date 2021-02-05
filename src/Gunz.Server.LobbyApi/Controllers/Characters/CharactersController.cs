using AutoMapper;
using Gunz.Server.Data;
using Gunz.Server.Data.Models.Characters;
using Gunz.Server.Domain.Contracts.Characters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunz.Server.LobbyApi.Controllers.Characters
{
    [ApiController]
    public class CharactersController : GunzControllerBase
    {
        public CharactersController(IMapper mapper, ILoggerFactory loggerFactory)
            : base(mapper, loggerFactory.CreateLogger<CharactersController>())
        {

        }

        [HttpGet]
        [Route("api/accounts/{accountId:int}/characters")]
        public async Task<List<Character>> GetAccountCharacters(int accountId)
        {
            CheckAccountAccess(accountId);

            using var context = new GunzDatabaseContext();
            var characters = await context.Characters
                .Where(c => c.AccountId == accountId)
                .OrderBy(c => c.Order)
                .ToListAsync();

            return _mapper.Map<List<Character>>(characters);
        }

        [HttpPost]
        [Route("api/accounts/{accountId:int}/characters")]
        public async Task<Character> AddAccountCharacter(int accountId, [FromBody] Character character)
        {
            CheckAccountAccess(accountId);

            using var context = new GunzDatabaseContext();

            if ((await context.Characters.FirstOrDefaultAsync(c => c.Name == character.Name)) != null)
                throw new System.Exception();

            var model = _mapper.Map<CharacterModel>(character);
            context.Characters.Add(model);
            await context.SaveChangesAsync();

            model = await context.Characters.FirstAsync(c => c.AccountId == model.AccountId);
            return _mapper.Map<Character>(model);
        }

    }
}
