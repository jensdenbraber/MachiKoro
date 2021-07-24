using MachiKoro.Api.Models;
using MachiKoro.Core;
using MachiKoro.Core.Models.Game;
using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Api.Services
{
    public interface IGameService
    {
        Task<bool> CreateAsync(Game game);
        Task<List<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(Guid gameId);
        Task<List<Player>> GetPlayersFromGameAsync(Guid gameId);
        Task<bool> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(Guid gameId);
        Task<bool> AddPlayerAsync(Guid gameId, Player player);
        Task<bool> RemovePlayerAsync(Guid gameId, Guid playerId);



        //Task<List<Post>> GetPostsAsync(GetAllPostsFilter filter = null, PaginationFilter paginationFilter = null);

        //Task<bool> CreatePostAsync(Post post);

        //Task<Post> GetPostByIdAsync(Guid postId);

        //Task<bool> UpdatePostAsync(Post postToUpdate);

        //Task<bool> DeletePostAsync(Guid postId);

        //Task<bool> UserOwnsPostAsync(Guid postId, string userId);

        //Task<List<Tag>> GetAllTagsAsync();

        //Task<bool> CreateTagAsync(Tag tag);

        //Task<Tag> GetTagByNameAsync(string tagName);

        //Task<bool> DeleteTagAsync(string tagName);
    }
}
