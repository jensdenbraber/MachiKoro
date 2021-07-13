using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DataObjectToDomainProfile : Profile
    {
        public DataObjectToDomainProfile()
        {
            CreateMap<Data.Models.Game, DomainModels.Game>();
            CreateMap<Data.Models.Player, DomainModels.Player>();
            CreateMap<Data.Models.PlayerProfile, DomainModels.PlayerProfile>();
        }
    }
}
