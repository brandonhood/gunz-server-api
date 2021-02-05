using AutoMapper;
using Gunz.Server.Data.Models.Characters;
using Gunz.Server.Domain.Contracts.Characters;

namespace Gunz.Server.LobbyApi.Mapping
{
    internal sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacterModel, Character>();
            CreateMap<Character, CharacterModel>();
        }
    }
}
