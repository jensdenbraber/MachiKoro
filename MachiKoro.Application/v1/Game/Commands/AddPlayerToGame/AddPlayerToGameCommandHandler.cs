using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;

public class AddPlayerToGameCommandHandler : IRequestHandler<AddPlayerToGameCommand, AddPlayerToGameResponse>
{
    private readonly IGamesRepository _gameRepository;

    public AddPlayerToGameCommandHandler(IGamesRepository gameRepository)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
    }

    public async Task<AddPlayerToGameResponse> Handle(AddPlayerToGameCommand request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        var player = new Domain.Models.Player.Player(request.PlayerId, PlayerType.Human, 3, new List<Domain.Models.Cards.Establishments.Basic.EstablishmentBase>(), new List<Domain.Models.Cards.Landmarks.Basic.LandMark>());

        bool added = await _gameRepository.AddPlayerToGameAsync(player, request.GameId, cancellationToken);

        if (!added)
        {
            return null;
        }

        return new AddPlayerToGameResponse()
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }
}