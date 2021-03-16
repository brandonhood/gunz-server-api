using Gunz.Server.Business.Characters;
using Gunz.Server.Domain.Contracts.Characters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gunz.Server.Api.Controllers.Characters
{
    [ApiController]
    public class CharactersController : GunzControllerBase
    {
        private readonly ICharacterManager _characterManager;

        public CharactersController(ICharacterManager characterManager)
        {
            _characterManager = characterManager;
        }

        [HttpGet]
        [Route("api/accounts/{accountId:int}/characters")]
        public async Task<List<Character>> GetAccountCharacters(int accountId)
            => await _characterManager.GetCharactersForAccountAsync(accountId, GetRequestingAccountInfo());

        [HttpPost]
        [Route("api/accounts/{accountId:int}/characters")]
        public async Task<Character> AddAccountCharacter(int accountId, [FromBody] Character character)
            => throw new NotImplementedException();

    }
}
