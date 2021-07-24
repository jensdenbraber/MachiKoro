using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DataObjectToDomainProfile : Profile
    {
        public DataObjectToDomainProfile()
        {
            CreateMap<Persistence.Models.Game, Models.CreateGame.CreateGameRequest>();
            CreateMap<Persistence.Models.Player, Models.GetPlayerProfile.GetPlayerProfileRequest>();
        }
    }
}
