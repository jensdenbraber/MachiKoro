using AutoMapper;
using MachiKoro.Contracts.v1.Requests;
using MachiKoro.Core.Models.Identity;
using MachiKoro.Infrastructure.Identity.Models;
using MachiKoro.Infrastructure.Identity.Models.Authentication;

namespace MachiKoro.Api.MappingProfiles
{
    public class ApiModelMappingProfile : Profile
    {
        public ApiModelMappingProfile()
        {
            CreateMap<Persistence.Models.Game, Models.CreateGame.CreateGameRequest>();
            CreateMap<Persistence.Models.Player, Models.GetPlayerProfile.GetPlayerProfileRequest>();


            CreateMap<Core.Models.Game.Game, Persistence.Models.Game>();
            CreateMap<Persistence.Models.Game, Core.Models.Game.Game>();

            CreateMap<Persistence.Models.Player, Core.Models.Player.Player>();
            CreateMap<Core.Models.Player.Player, Persistence.Models.Player>();

            CreateMap<Persistence.Models.PlayerProfile, Core.Models.PlayerProfile.PlayerProfile>();
            CreateMap<Core.Models.PlayerProfile.PlayerProfile, Persistence.Models.PlayerProfile>();

            CreateMap<Core.Models.User.MachiKoroUser, ApplicationUser>();
            CreateMap<ApplicationUser, Core.Models.User.MachiKoroUser>();

            CreateMap<Configuration.Token, Token>();
            CreateMap<Token, Configuration.Token>();

            //CreateMap<Models.CreateGame.CreateGameRequest, Persistence.Models.Game>();
            //CreateMap<Models.GetPlayerProfile.GetPlayerProfileResponse, Persistence.Models.PlayersStatistics>();
            //CreateMap<Models.PlayerStatistics, Data.Models.PlayerStatistics>();

            //CreateMap<Post, PostResponse>()
            //    .ForMember(dest => dest.Tags, opt =>
            //        opt.MapFrom(src => src.Tags.Select(x => new TagResponse { Name = x.TagName })));

            //CreateMap<Tag, TagResponse>();

            //CreateMap<CreateGameRequest, CreateGameResponse>();
            //CreateMap<GetGameRequest, GetGameResponse>();
            ////CreateMap<Player, PlayerResponse>();
            //CreateMap<GetPlayerProfileResponse, GetPlayerProfileResponse>();

            CreateMap<UserRegistrationRequest, CreateUserRequest>();
            CreateMap<UserLoginRequest, LoginUserRequest>();

            CreateMap<Models.CreateGame.CreateGameRequest, Core.Models.CreateGame.CreateGameRequest>();
            CreateMap<Models.CreateGame.CreateGameResponse, Core.Models.CreateGame.CreateGameResponse>();

            CreateMap<Models.GetGame.GetGameRequest, Core.Models.GetGame.GetGameRequest>();
            CreateMap<Models.GetGame.GetGameResponse, Core.Models.GetGame.GetGameResponse>();

            CreateMap<Models.GetPlayerProfile.GetPlayerProfileRequest, Core.Models.GetPlayerProfile.GetPlayerProfileRequest>();
            CreateMap<Models.GetPlayerProfile.GetPlayerProfileResponse, Core.Models.GetPlayerProfile.GetPlayerProfileResponse>();

            //CreateMap<PaginationQuery, PaginationFilter>();
            //CreateMap<GetAllPostsQuery, GetAllPostsFilter>();

            //CreateMap<, Game>();
            //CreateMap<, Player>();
            //CreateMap<, PlayerStatistics>();
        }
    }
}
