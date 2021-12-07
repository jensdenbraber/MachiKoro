using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IGamesRepository
    {
        Task<bool> CreateAsync(Core.Models.Game.Game gameData);

        Task<List<Core.Models.Game.Game>> GetGamesAsync();

        Task<Core.Models.Game.Game> GetGameAsync(Guid id);

        Task<List<Core.Models.Player.Player>> GetPlayersFromGameAsync(Guid id);

        Task<bool> DeleteAsync(Guid gameId);
        
        Task<bool> UpdateAsync(Core.Models.Game.Game gameData);
        Task<bool> AddPlayerToGameAsync(Guid playerId, Guid gameId);
        Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId);
    }
}
