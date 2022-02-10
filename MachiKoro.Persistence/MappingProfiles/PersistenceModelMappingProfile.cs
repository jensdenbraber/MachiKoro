using AutoMapper;
using MachiKoro.Domain.Models.User;
using MachiKoro.Persistence.Identity.Models;

namespace MachiKoro.Persistence.MappingProfiles
{
    public class PersistenceModelMappingProfile : Profile
    {
        public PersistenceModelMappingProfile()
        {
            CreateMap<Models.Game, Domain.Models.Game.Game>();
            CreateMap<Domain.Models.Game.Game, Models.Game>();

            CreateMap<Models.Player, Domain.Models.Player.Player>();
            CreateMap<Domain.Models.Player.Player, Models.Player>();

            //CreateMap<Models.PlayerProfile, Core.Models.PlayerProfile.PlayerProfile>();
            CreateMap<MachiKoroUser, ApplicationUser>();
            CreateMap<ApplicationUser, MachiKoroUser>();
        }
    }
}