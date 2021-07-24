using AutoMapper;
using MachiKoro.Contracts.v1.Responses;
using MachiKoro.Core.Players;
using MachiKoro.Api.Models.CreateGame;
using MachiKoro.Api.Models.GetGame;
using MachiKoro.Api.Models.GetPlayerProfile;
using MachiKoro.Core.Models.Game;

namespace MachiKoro.Api.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            //CreateMap<Post, PostResponse>()
            //    .ForMember(dest => dest.Tags, opt =>
            //        opt.MapFrom(src => src.Tags.Select(x => new TagResponse { Name = x.TagName })));

            //CreateMap<Tag, TagResponse>();

            CreateMap<CreateGameRequest, CreateGameResponse>();
            CreateMap<GetGameRequest, GetGameResponse>();
            //CreateMap<Player, PlayerResponse>();
            CreateMap<GetPlayerProfileResponse, GetPlayerProfileResponse>();
        }
    }
}