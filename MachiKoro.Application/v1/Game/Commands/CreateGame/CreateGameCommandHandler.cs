using MachiKoro.Application.CardDecks;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Extensions;
using MachiKoro.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreateGameResponse>
{
    private readonly IGamesRepository _gameRepository;
    private readonly INotifyPlayerService _playerService;

    public CreateGameCommandHandler(IGamesRepository gameRepository, INotifyPlayerService playerService)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
    }

    public async Task<CreateGameResponse> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        var player = new Domain.Models.Player.Player()
        {
            Id = request.PlayerId,
            CoinAmount = 3,
            PlayerType = PlayerType.Human,
            EstablishmentCards = new List<Domain.Models.Cards.Establishments.Basic.EstablishmentBase>(),
            LandmarkCards = new List<Domain.Models.Cards.Landmarks.Basic.LandMark>()
        };

        var settings = new Domain.Models.Game.GameSettings();

        var game = new Domain.Models.Game.Game()
        {
            Id = Guid.NewGuid(),
            MaxNumberOfPlayers = request.MaxNumberOfPlayers,
            ExpensionType = request.ExpensionType,
            Players = new CircularList<Domain.Models.Player.Player> { player },
            CardDecks = new CardDeckBuilder(_playerService).BuildCardDecksBasicGame(),
            Settings = settings
        };

        bool created = await _gameRepository.CreateAsync(game, cancellationToken);

        if (!created)
        {
            return null;
        }

        return new CreateGameResponse()
        {
            GameId = game.Id
        };
    }
}