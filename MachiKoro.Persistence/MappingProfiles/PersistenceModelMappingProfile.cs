using AutoMapper;
using MachiKoro.Domain.Models.User;
using MachiKoro.Persistence.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.MappingProfiles
{
    public class PersistenceModelMappingProfile : Profile
    {
        public PersistenceModelMappingProfile()
        {
            //CreateMap<Models.Game, Core.Models.Game.Game>();
            //CreateMap<Core.Models.Game.Game, Models.Game>();

            //CreateMap<Models.Player, Core.Models.Player.Player>();
            //CreateMap<Core.Models.Player.Player, Models.Player>();

            //CreateMap<Models.PlayerProfile, Core.Models.PlayerProfile.PlayerProfile>();
            CreateMap<MachiKoroUser, ApplicationUser> ();
            CreateMap<ApplicationUser, MachiKoroUser> ();


        }
    }
}
