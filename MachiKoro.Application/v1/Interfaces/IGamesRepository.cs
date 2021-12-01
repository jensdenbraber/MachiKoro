using MachiKoro.Core.Models.Game;
using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IGamesRepository
    {
        Task<bool> CreateAsync(Game gameData);
        Task<List<Game>> GetGamesAsync();
        Task<Game> GetGameAsync(Guid id);
        Task<List<Player>> GetPlayersFromGameAsync(Guid id);
        Task<bool> DeleteAsync(Guid gameId);
        Task<bool> UpdateAsync(Game gameData);
        Task<bool> AddPlayerToGameAsync(Guid playerId, Guid gameId);
        Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId);
    }
}
