using MachiKoro.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Data.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly PlayerDataContext _playerDataContext;

        public PlayersRepository(PlayerDataContext playerDataContext)
        {
            _playerDataContext = playerDataContext;
        }

        public async Task<bool> Create(Player player)
        {
            await _playerDataContext.Players.AddAsync(player);

            var created = await _playerDataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _playerDataContext.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerById(Guid id)
        {
            return await _playerDataContext.Players.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Player> GetPlayerByUserName(string userName)
        {
            return await _playerDataContext.Players.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<bool> Delete(Guid playerId)
        {
            var player = await _playerDataContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.Id == playerId);

            if (player == null)
                return false;

            _playerDataContext.Players.Remove(player);

            var deleted = await _playerDataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<PlayerProfile> GetPlayerProfile(Guid userId)
        {
            return await _playerDataContext.PlayersProfiles.FirstOrDefaultAsync(x => x.Player.Id == userId);
        }

        public async Task<PlayersStatistics> GetPlayerStatistics(Guid userId)
        {
            return await _playerDataContext.PlayersStatistics.FirstOrDefaultAsync(x => x.PlayerProfile.Player.Id == userId);
        }

        public async Task<bool> Update(Player player)
        {
            _playerDataContext.Players.Update(player);

            var updated = await _playerDataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<Player> GetPlayerWithMostGamesWon()
        {
            throw new NotImplementedException();
        }
        public async Task<Player> GetPlayerWithMostGamesLost()
        {
            throw new NotImplementedException();
        }
    }
}
