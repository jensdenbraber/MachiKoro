using AutoMapper;
using MachiKoro.Api.Models.CreateGame;

namespace MachiKoro.Api.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateGameRequest, Core.Models.CreateGame.CreateGameRequest>();

            //CreateMap<PaginationQuery, PaginationFilter>();
            //CreateMap<GetAllPostsQuery, GetAllPostsFilter>();

            //CreateMap<, Game>();
            //CreateMap<, Player>();
            //CreateMap<, PlayerStatistics>();
        }
    }
}