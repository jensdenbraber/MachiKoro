using MachiKoro.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.StartGame;

public class StartGameRequestHandler : IRequestHandler<StartGameRequest, Unit>
{
    private readonly INotifyPlayerService _notifyPlayerService;
    private readonly IGamesRepository _gameRepository;

    public StartGameRequestHandler(INotifyPlayerService gameClient, IGamesRepository gameRepository)
    {
        _notifyPlayerService = gameClient ?? throw new ArgumentNullException(nameof(gameClient));
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
    }

    public async Task<Unit> Handle(StartGameRequest request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        var game = await _gameRepository.GetGameAsync(request.GameId, cancellationToken);

        var playersId = game.Players.Select(p => p.Id);

        string json = System.Text.Json.JsonSerializer.Serialize(playersId);

        await _notifyPlayerService.StartGame(json);

        return Unit.Value;
    }
}