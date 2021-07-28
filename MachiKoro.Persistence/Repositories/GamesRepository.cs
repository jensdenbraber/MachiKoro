﻿using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameDataContext _gameDataContext;

        public GamesRepository(GameDataContext gameDataContext)
        {
            _gameDataContext = gameDataContext;
        }

        public async Task<bool> CreateAsync(Game gameData)
        {
            await _gameDataContext.Games.AddAsync(gameData);

            var created = await _gameDataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            return await _gameDataContext.Games.ToListAsync();
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            return await _gameDataContext.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Player>> GetPlayersFromGame(Guid id)
        {
            //return await _gameDataContext.Games.FirstOrDefaultAsync(g => g.Id == id).Players;

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid gameId)
        {
            var game = await _gameDataContext.Games.AsNoTracking().SingleOrDefaultAsync(x => x.Id == gameId);

            if (game == null)
                return false;

            _gameDataContext.Games.Remove(game);

            var deleted = await _gameDataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> UpdateAsync(Game gameData)
        {
            _gameDataContext.Games.Update(gameData);

            var updated = await _gameDataContext.SaveChangesAsync();
            return updated > 0;
        }

        Task<bool> IGamesRepository.CreateAsync(Core.Models.Game.Game gameData)
        {
            throw new NotImplementedException();
        }

        Task<List<Core.Models.Game.Game>> IGamesRepository.GetGamesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Core.Models.Game.Game> IGamesRepository.GetGameAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<Core.Players.Player>> IGamesRepository.GetPlayersFromGame(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGamesRepository.UpdateAsync(Core.Models.Game.Game gameData)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGamesRepository.AddPlayerToGameAsync(Guid playerId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGamesRepository.RemovePlayerFromGameAsync(Guid playerId, Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}