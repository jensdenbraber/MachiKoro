using AutoMapper;
using MachiKoro.Api.DomainModels;
using MachiKoro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGamesRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(Game game)
        {
            var gameData = _mapper.Map<Data.Models.Game>(game);
            var isCreated = await _gameRepository.CreateAsync(gameData);
            return isCreated;
        }

        public async Task<bool> DeleteGameAsync(Guid gameId)
        {
            var isDeleted = await _gameRepository.DeleteAsync(gameId);
            return isDeleted;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            var gamesData = await _gameRepository.GetGamesAsync();
            var games = _mapper.Map<List<Game>>(gamesData);
            return games;
        }

        public async Task<Game> GetGameByIdAsync(Guid gameId)
        {
            var gameData = await _gameRepository.GetGameAsync(gameId);
            var game = _mapper.Map<Game>(gameData);
            return game;
        }

        public async Task<List<Player>> GetPlayersFromGameAsync(Guid gameId)
        {
            var playersData = await _gameRepository.GetPlayersFromGame(gameId);
            var players = _mapper.Map<List<Player>>(playersData);
            return players;
        }

        public async Task<bool> AddPlayerAsync(Guid gameId, Player player)
        {
            var game = await GetGameByIdAsync(gameId);

            game.Players.Add(player);

            return await UpdateGameAsync(game);
        }

        public async Task<bool> RemovePlayerAsync(Guid gameId, Guid playerId)
        {
            var game = await GetGameByIdAsync(gameId);

            game.Players.RemoveAll(p => p.Id == playerId);

            return await UpdateGameAsync(game);
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            var gameData = _mapper.Map<Data.Models.Game>(game);
            var isUpdated = await _gameRepository.UpdateAsync(gameData);
            return isUpdated;
        }
    }
}
