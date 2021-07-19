using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DomainToDataObjectProfile : Profile
    {
        public DomainToDataObjectProfile()
        {
            CreateMap<Models.Game, Data.Models.Game>();
            CreateMap<Models.Player, Data.Models.Player>();
            //CreateMap<Models.PlayerStatistics, Data.Models.PlayerStatistics>();
        }
    }
}
