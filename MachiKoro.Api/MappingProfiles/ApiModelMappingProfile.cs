using AutoMapper;
using MachiKoro.Api.Contracts.Game.StartGame;
using MachiKoro.Application.v1.Identity.Commands.Login;
using MachiKoro.Application.v1.Identity.Commands.Refresh;
using MachiKoro.Application.v1.Identity.Commands.Registration;
using MachiKoro.Domain.Models.Game;
using MachiKoro.Domain.Models.User;
using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Identity.Models.Authentication;
using System.Diagnostics.CodeAnalysis;

namespace MachiKoro.Api.MappingProfiles;

[ExcludeFromCodeCoverage]
public class ApiModelMappingProfile : Profile
{
    public ApiModelMappingProfile()
    {
        CreateMap<Contracts.Identity.Registration.CreateUserRequest, CreateUserRequest>();

        CreateMap<Contracts.Identity.Login.LoginUserRequest, LoginUserRequest>();
        CreateMap<LoginUserResponse, Contracts.Identity.Login.LoginUserResponse>();

        CreateMap<Contracts.Identity.RefreshToken.RefreshTokenRequest, RefreshTokenRequest>();
        CreateMap<RefreshTokenResponse, Contracts.Identity.RefreshToken.RefreshTokenResponse>();

        CreateMap<Persistence.Models.Game, Contracts.Game.CreateGame.CreateGameRequest>();
        //CreateMap<Persistence.Models.Player, Contracts.Player.GetPlayerProfile.GetPlayerProfileRequest>();

        CreateMap<Game, Persistence.Models.Game>();
        CreateMap<Persistence.Models.Game, Game>();

        CreateMap<Persistence.Models.Player, Domain.Models.Player.Player>();
        CreateMap<Domain.Models.Player.Player, Persistence.Models.Player>();

        CreateMap<StartGameRequest, MachiKoro.Application.v1.Game.Commands.StartGame.StartGameRequest>();

        CreateMap<MachiKoro.Api.Contracts.Game.StartGame.GetGameRequest, MachiKoro.Application.v1.Game.Queries.GetGame.GetGameRequest>();

        //CreateMap<Persistence.Models.PlayerProfile, PlayerProfile>();
        //CreateMap<PlayerProfile, Persistence.Models.PlayerProfile>();

        CreateMap<MachiKoroUser, ApplicationUser>();
        CreateMap<ApplicationUser, MachiKoroUser>();

        CreateMap<Contracts.Identity.Token, Token>();
        CreateMap<Token, Contracts.Identity.Token>();

        //CreateMap<Application.v1.Game.Commands.CreateGame.CreateGameRequest, Persistence.Models.Game>();
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

        CreateMap<CreateUserRequest, CreateUserRequest>();
        CreateMap<LoginUserRequest, LoginUserRequest>();

        CreateMap<Contracts.Game.CreateGame.CreateGameRequest, Application.v1.Game.Commands.CreateGame.CreateGameCommand>();
        CreateMap<Contracts.Game.CreateGame.CreateGameResponse, Application.v1.Game.Commands.CreateGame.CreateGameResponse>();

        CreateMap<Contracts.Game.AddPlayer.AddPlayerToGameRequest, Application.v1.Game.Commands.AddPlayerToGame.AddPlayerToGameCommand>();
        CreateMap<Contracts.Game.AddPlayer.AddPlayerToGameResponse, Application.v1.Game.Commands.AddPlayerToGame.AddPlayerToGameResponse>();

        CreateMap<StartGameRequest, Application.v1.Game.Queries.GetGame.GetGameRequest>();
        CreateMap<Contracts.Game.StartGame.GetGameResponse, Application.v1.Game.Queries.GetGame.GetGameResponse>();

        CreateMap<Contracts.Game.Choose.ChooseRequest, Application.v1.Game.Commands.Choose.ChooseRequest>();
        CreateMap<Contracts.Game.Choose.ChooseResponse, Application.v1.Game.Commands.Choose.ChooseResponse>();

        CreateMap<Contracts.Game.ExpansionTypeResponse, Domain.Enums.ExpensionType>();

        //CreateMap<Contracts.Player.GetPlayerProfile.GetPlayerProfileRequest, Application.v1.Player.Queries.GetPlayerProfile.GetPlayerProfileRequest>();
        //CreateMap<Contracts.Player.GetPlayerProfile.GetPlayerProfileResponse, Application.v1.Player.Queries.GetPlayerProfile.GetPlayerProfileResponse>();

        //CreateMap<PaginationQuery, PaginationFilter>();
        //CreateMap<GetAllPostsQuery, GetAllPostsFilter>();

        //CreateMap<, Game>();
        //CreateMap<, Player>();
        //CreateMap<, PlayerStatistics>();
    }
}