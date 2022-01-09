using AutoMapper;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly IMapper _mapper;
        private readonly GameDataContext _gameDataContext;

        public GamesRepository(IMapper mapper, GameDataContext gameDataContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _gameDataContext = gameDataContext ?? throw new ArgumentNullException(nameof(gameDataContext));
        }

        public async Task<bool> CreateAsync(Domain.Models.Game.Game game)
        {
            var gameData = _mapper.Map<Game>(game);

            await _gameDataContext.Games.AddAsync(gameData);

            var created = await _gameDataContext.SaveChangesAsync();
            return created > 0;
        }

        public Task<List<Domain.Models.Game.Game>> GetGamesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.Game.Game> GetGameAsync(Guid id)
        {
            Game gameData = await _gameDataContext.Games.FindAsync(id);

            if (gameData == null)
                return null;

            var game = _mapper.Map<Domain.Models.Game.Game>(gameData);

            return game;
        }

        public async Task<bool> UpdateAsync(Domain.Models.Game.Game game)
        {
            var gameData = _mapper.Map<Game>(game);

            _gameDataContext.Games.Update(gameData);

            var updated = await _gameDataContext.SaveChangesAsync();
            return updated > 0;
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

        public Task<bool> AddPlayerToGameAsync(Guid playerId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Player>> GetPlayersFromGameAsync(Guid id)
        //{
        //    //return await _gameDataContext.Games.FirstOrDefaultAsync(g => g.Id == id).Players;

        //    throw new NotImplementedException();
        //}
    }
}