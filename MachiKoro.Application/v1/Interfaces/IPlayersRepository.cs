using MachiKoro.Core.Models.PlayerProfile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IPlayersRepository
    {
        public Task<bool> Create(Core.Models.Player.Player player);
        public Task<List<Core.Models.Player.Player>> GetPlayers();
        public Task<Core.Models.Player.Player> GetPlayerById(Guid id);
        public Task<Core.Models.Player.Player> GetPlayerByUserName(string userName);
        public Task<bool> Delete(Guid playerId);
        public Task<PlayerProfile> GetPlayerProfile(Guid userId);
        //public Task<PlayersStatistics> GetPlayerStatistics(Guid userId);
        public Task<bool> Update(Core.Models.Player.Player player);
        public Task<Core.Models.Player.Player> GetPlayerWithMostGamesWon();
        public Task<Core.Models.Player.Player> GetPlayerWithMostGamesLost();
    }
}
