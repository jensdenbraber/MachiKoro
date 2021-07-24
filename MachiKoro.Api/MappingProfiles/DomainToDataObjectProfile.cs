using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DomainToDataObjectProfile : Profile
    {
        public DomainToDataObjectProfile()
        {
            CreateMap<Models.CreateGame.CreateGameRequest, Persistence.Models.Game>();
            CreateMap<Models.GetPlayerProfile.GetPlayerProfileResponse, Persistence.Models.Player>();
            //CreateMap<Models.PlayerStatistics, Data.Models.PlayerStatistics>();
        }
    }
}
