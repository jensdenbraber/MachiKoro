using MachiKoro.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Data.Repositories
{
    public interface IGamesRepository
    {
        Task<bool> CreateAsync(Game gameData);

        Task<List<Game>> GetGamesAsync();

        Task<Game> GetGameAsync(Guid id);

        Task<List<Player>> GetPlayersFromGame(Guid id);

        Task<bool> DeleteAsync(Guid gameId);
        
        Task<bool> UpdateAsync(Game gameData);
    }
}
