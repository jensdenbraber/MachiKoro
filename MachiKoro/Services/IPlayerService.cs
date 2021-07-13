using MachiKoro.Api.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Api.Services
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(Player player);
        Task<Player> GetPlayerByIdAsync(Guid playerId);
        Task<PlayerProfile> GetPlayerProfileAsync(Guid playerId);
        Task<List<Player>> GetAllPlayersAsync();
        Task<List<Game>> GetGamesAsync(Guid playerId);
        Task<Game> GetGameAsync(Guid playerId, Guid gameId);
        Task<bool> UpdatePlayerAsync(Player player);      
        Task<bool> DeletePlayerAsync(Guid playerId);
    }
}
