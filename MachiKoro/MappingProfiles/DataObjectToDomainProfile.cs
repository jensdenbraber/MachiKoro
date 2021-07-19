using AutoMapper;

namespace MachiKoro.Api.MappingProfiles
{
    public class DataObjectToDomainProfile : Profile
    {
        public DataObjectToDomainProfile()
        {
            CreateMap<Data.Models.Game, Models.Game>();
            CreateMap<Data.Models.Player, Models.Player>();
            CreateMap<Data.Models.PlayerProfile, Models.PlayerProfile>();
        }
    }
}
