using System.Linq;
using AutoMapper;
using MachiKoro.Contracts.v1.Responses;
using MachiKoro.Api.DomainModels;

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

            CreateMap<Game, GameResponse>();
            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerProfile, PlayerProfileResponse>();
        }
    }
}