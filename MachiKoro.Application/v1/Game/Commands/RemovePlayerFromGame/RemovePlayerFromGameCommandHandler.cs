using MachiKoro.Application.v1.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame;

public class RemovePlayerFromGameCommandHandler : IRequestHandler<RemovePlayerFromGameCommand, RemovePlayerFromGameResponse>
{
    private readonly IGamesRepository _gameRepository;

    public RemovePlayerFromGameCommandHandler(IGamesRepository gameRepository)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
    }

    public async Task<RemovePlayerFromGameResponse> Handle(RemovePlayerFromGameCommand request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        bool removed = await _gameRepository.RemovePlayerFromGameAsync(request.PlayerId, request.GameId, cancellationToken);

        if (!removed)
        {
            return null;
        }

        return new RemovePlayerFromGameResponse()
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }
}