using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IGamesRepository
    {
        Task<bool> CreateAsync(Domain.Models.Game.Game gameData);

        Task<List<Domain.Models.Game.Game>> GetGamesAsync();

        Task<Domain.Models.Game.Game> GetGameAsync(Guid id);

        //Task<List<Domain.Models.Player.Player>> GetPlayersFromGameAsync(Guid id);
        Task<bool> UpdateAsync(Domain.Models.Game.Game gameData);

        Task<bool> DeleteAsync(Guid gameId);

        Task<bool> AddPlayerToGameAsync(Guid playerId, Guid gameId);

        Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId);
    }
}