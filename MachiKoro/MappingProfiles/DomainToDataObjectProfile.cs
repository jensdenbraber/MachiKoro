using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DomainToDataObjectProfile : Profile
    {
        public DomainToDataObjectProfile()
        {
            CreateMap<DomainModels.Game, Data.Models.Game>();
            CreateMap<DomainModels.Player, Data.Models.Player>();
            //CreateMap<DomainModels.PlayerStatistics, Data.Models.PlayerStatistics>();
        }
    }
}
