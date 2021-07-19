using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DomainToDataObjectProfile : Profile
    {
        public DomainToDataObjectProfile()
        {
            CreateMap<Models.CreateGame.CreateGameRequest, Data.Models.Game>();
            CreateMap<Models.GetPlayerProfile.GetPlayerProfileResponse, Data.Models.Player>();
            //CreateMap<Models.PlayerStatistics, Data.Models.PlayerStatistics>();
        }
    }
}
