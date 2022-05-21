using AutoMapper;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Models.CardDecks;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Cards.Landmarks.Basic;
using MachiKoro.Persistence.Data;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories;

public class GamesRepository : IGamesRepository
{
    private readonly IMapper _mapper;
    private readonly GameDataContext _gameDataContext;

    public GamesRepository(IMapper mapper, GameDataContext gameDataContext)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _gameDataContext = gameDataContext ?? throw new ArgumentNullException(nameof(gameDataContext));
    }

    public async Task<bool> CreateAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken = default)
    {
        var cardDecks = System.Text.Json.JsonSerializer.Serialize(game.CardDecks);
        var startingEstablishments = System.Text.Json.JsonSerializer.Serialize(game.Settings.StartingEstablishmentCards);
        var startingLandmarks = System.Text.Json.JsonSerializer.Serialize(game.Settings.StartingLandmarkCards);

        var gameData = _mapper.Map<Game>(game);
        gameData.StartingDecks = cardDecks;
        gameData.StartingEstablishments = startingEstablishments;
        gameData.StartingLandmarks = startingLandmarks;

        gameData.Players.First().UserId = gameData.Players.First().Id;
        gameData.Players.First().Id = Guid.NewGuid();

        await _gameDataContext.Games.AddAsync(gameData, cancellationToken);

        var created = await _gameDataContext.SaveChangesAsync();
        return created > 0;
    }

    public Task<List<Domain.Models.Game.Game>> GetGamesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Models.Game.Game> GetGameAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var gameData = await _gameDataContext.Games.FindAsync(new object[] { id }, cancellationToken);

        if (gameData == null)
            return null;

        var game = _mapper.Map<Domain.Models.Game.Game>(gameData);

        //var qwe = System.Text.Json.JsonSerializer.Deserialize<List<CardDeck>>(gameData.StartingDecks);

        game.Settings = new Domain.Models.Game.GameSettings();

        //game.Settings.StartingEstablishmentCards = System.Text.Json.JsonSerializer.Deserialize<List<EstablishmentBase>>(gameData.StartingEstablishments);
        //game.Settings.StartingLandmarkCards = System.Text.Json.JsonSerializer.Deserialize<List<LandMark>>(gameData.StartingLandmarks);

        return game;
    }

    public async Task<bool> UpdateAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken = default)
    {
        var gameData = _mapper.Map<Game>(game);

        _gameDataContext.Games.Update(gameData);

        var updated = await _gameDataContext.SaveChangesAsync(cancellationToken);
        return updated > 0;
    }

    public async Task<bool> DeleteAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        var game = await _gameDataContext.Games.AsNoTracking().SingleOrDefaultAsync(x => x.Id == gameId);

        if (game == null)
            return false;

        _gameDataContext.Games.Remove(game);

        var deleted = await _gameDataContext.SaveChangesAsync(cancellationToken);
        return deleted > 0;
    }

    public async Task<bool> AddPlayerToGameAsync(Domain.Models.Player.Player player, Guid gameId, CancellationToken cancellationToken = default)
    {
        var playerData = _mapper.Map<Player>(player);
        playerData.UserId = player.Id;
        playerData.Id = Guid.NewGuid();

        var gameData = await _gameDataContext.Games.Include(g => g.Players).FirstAsync(g => g.Id == gameId, cancellationToken);

        playerData.Games = new List<Game> { gameData };
        playerData.GamePlayers = new List<GamePlayer> { new GamePlayer() { Game = gameData, GamesId = gameData.Id, Player = playerData, PlayersId = playerData.Id } };

        gameData.Players.Add(playerData);

        _gameDataContext.Games.Update(gameData);

        var updated = await _gameDataContext.SaveChangesAsync(cancellationToken);
        return updated > 0;
    }

    public Task<bool> RemovePlayerFromGameAsync(Guid playerId, Guid gameId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}