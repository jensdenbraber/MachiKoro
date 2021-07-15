using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Data.Repositories
{
    public interface IPlayersRepository
    {
        public Task<bool> Create(Player player);
        public Task<List<Player>> GetPlayers();
        public Task<Player> GetPlayerById(Guid id);
        public Task<Player> GetPlayerByUserName(string userName);
        public Task<bool> Delete(Guid playerId);
        //public Task<PlayerProfile> GetPlayerProfile(Guid userId);
        //public Task<PlayersStatistics> GetPlayerStatistics(Guid userId);
        public Task<bool> Update(Player player);
        public Task<Player> GetPlayerWithMostGamesWon();
        public Task<Player> GetPlayerWithMostGamesLost();
    }
}
