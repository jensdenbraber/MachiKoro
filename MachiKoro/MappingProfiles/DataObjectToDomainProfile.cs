using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DataObjectToDomainProfile : Profile
    {
        public DataObjectToDomainProfile()
        {
            CreateMap<Data.Models.Game, Models.CreateGame.CreateGameRequest>();
            CreateMap<Data.Models.Player, Models.GetPlayerProfile.GetPlayerProfileRequest>();
        }
    }
}
