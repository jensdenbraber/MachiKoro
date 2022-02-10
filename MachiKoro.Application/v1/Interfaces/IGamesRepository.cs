using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IGamesRepository
    {
        Task<bool> CreateAsync(Domain.Models.Game.Game gameData, CancellationToken cancellationToken);

        Task<List<Domain.Models.Game.Game>> GetGamesAsync(CancellationToken cancellationToken);

        Task<Domain.Models.Game.Game> GetGameAsync(Guid id, CancellationToken cancellationToken);

        //Task<List<Domain.Models.Player.Player>> GetPlayersFromGameAsync(Guid id);
        Task<bool> UpdateAsync(Domain.Models.Game.Game gameData, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(Guid gameId, CancellationToken cancellationToken);

        Task<bool> AddPlayerToGameAsync(Domain.Models.Player.Player player, Guid gameId, CancellationToken cancellationToken);

        Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId, CancellationToken cancellationToken);
    }
}