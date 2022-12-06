using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

[SignalRHub(path: "/hubs/gameHub")]
public class GameHubContext : INotifyPlayerService
{
    private readonly IHubContext<GameHub> _hubContext;

    public GameHubContext(IHubContext<GameHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [SignalRMethod(name: "sendMessage2", SignalRSwaggerGen.Enums.Operation.Get)]
    public async Task SendMessage2(string user, string message)
    {
        throw new NotImplementedException();
    }

    [SignalRMethod(name: "sendNotificationDiceRollAsync", SignalRSwaggerGen.Enums.Operation.Get)]
    public async Task SendNotificationDiceRollAsync(object message, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.All.SendAsync("DiceRoll", message, cancellationToken);
    }

    public async Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("ConstructionEstablishmentsOptions", message, cancellationToken);
    }

    public async Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("ConstructionLandmarksOptions", message, cancellationToken);
    }

    public async Task SendNotificationPlayersIncomeAsync(Guid playerId, object message, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("Income", message, cancellationToken);
    }

    public async Task SendNotificationWinnerAsync(Guid playerId, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.All.SendAsync("Winner", playerId, cancellationToken);
    }

    public async Task SendNotificationTargetAsync(IEnumerable<EstablishmentBase> targetEstablishments, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.All.SendAsync("TargetEstablishments", targetEstablishments.ToList(), cancellationToken);
    }

    public async Task SendNotificationPlayerCoinsAsync(Domain.Models.Player.Player player, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.All.SendAsync("", player.CoinAmount, cancellationToken);
    }

    public async Task SendNotificationPlayersCoinsAsync(IEnumerable<Domain.Models.Player.Player> players, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.All.SendAsync("PlayersCoins", players.ToList(), cancellationToken);
    }

    public Task SendNotificationDiceRerollAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task SendNotificationDiceAmountAsync(Guid playerId, CancellationToken cancellationToken = default)
    {
        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("DiceAmount", cancellationToken);
    }

    public Task SendNotificationExtraTurnAsync(Domain.Models.Player.Player activePlayer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SendNotificationChooseTargetOpponentAsync(List<Domain.Models.Player.Player> opponents, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SendNotificationEstablishmentsBonusAsync(List<CardCategory> cardCategories, int bonus, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task SendMessage(string user, string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task StartGame(string game)
    {
        await _hubContext.Clients.All.SendAsync("StartGame", game);
    }
}