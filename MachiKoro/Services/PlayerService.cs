using AutoMapper;
using MachiKoro.Api.DomainModels;
using MachiKoro.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Api.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayersRepository playerRepository, IMapper mapper)
        {
            _playersRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreatePlayerAsync(Player player)
        {
            throw new NotImplementedException();
            //var playerData = _mapper.Map<Data.Models.Player>(player);
            //bool isCreated = await _playersRepository.Create(playerData);
            //return isCreated;
        }

        public async Task<bool> DeletePlayerAsync(Guid playerId)
        {
            bool isDeleted = await _playersRepository.Delete(playerId);
            return isDeleted;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            var playersData = await _playersRepository.GetPlayers();
            var players = _mapper.Map<List<Player>>(playersData);
            return players;
        }

        public async Task<Game> GetGameAsync(Guid playerId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Game>> GetGamesAsync(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayerByIdAsync(Guid playerId)
        {
            var playerData = await _playersRepository.GetPlayerById(playerId);
            var player = _mapper.Map<Player>(playerData);
            return player;
        }

        public async Task<PlayerProfile> GetPlayerProfileAsync(Guid playerId)
        {
            throw new NotImplementedException();
            //var playerProfileData = await _playersRepository.GetPlayerProfile(playerId);
            //var playerProfile = _mapper.Map<PlayerProfile>(playerProfileData);
            //return playerProfile;
        }

        public async Task<bool> UpdatePlayerAsync(Player player)
        {
            throw new NotImplementedException();
            //var playerData = _mapper.Map<Data.Models.Player>(player);
            //var isUpdated = await _playersRepository.Update(playerData);
            //return isUpdated;
        }
    }
}
