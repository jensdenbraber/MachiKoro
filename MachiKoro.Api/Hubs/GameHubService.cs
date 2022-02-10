using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs
{
    public class GameHubService
    {
        private readonly IHubContext<GameHub, IGameClient> _gameHub;

        public GameHubService(IHubContext<GameHub, IGameClient> gameHub)
        {
            _gameHub = gameHub;
        }

        [SignalRMethod(name: "SendMessage2", Microsoft.OpenApi.Models.OperationType.Get)]
        public async Task SendMessage2(string user, string message)
        {
            throw new NotImplementedException();
        }

        [SignalRMethod(name: "RollDice", Microsoft.OpenApi.Models.OperationType.Get)]
        public async Task RollDice()
        {
            //await _gameHub.Clients.All.RollDice();
        }

        public async Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid cardId)
        {
            //await _gameHub.Clients.All.ConstructEstabishment(cardId);
        }

        //public async Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.Client(playerId.ToString()).SendAsync("ConstructionLandmarksOptions", message, cancellationToken);
        //}

        //public async Task SendNotificationPlayersIncomeAsync(Guid playerId, object message, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.Client(playerId.ToString()).SendAsync("Income", message, cancellationToken);
        //}

        //public async Task SendNotificationWinnerAsync(Guid playerId, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.All.SendAsync("Winner", playerId, cancellationToken);
        //}

        //public async Task SendNotificationTargetAsync(IEnumerable<EstablishmentBase> targetEstablishments, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.All.SendAsync("TargetEstablishments", targetEstablishments.ToList(), cancellationToken);
        //}

        //public async Task SendNotificationPlayerCoinsAsync(Domain.Models.Player.Player player, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.All.SendAsync("", player.CoinAmount, cancellationToken);
        //}

        //public async Task SendNotificationPlayersCoinsAsync(IEnumerable<Domain.Models.Player.Player> players, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.All.SendAsync("PlayersCoins", players.ToList(), cancellationToken);
        //}

        //public Task SendNotificationDiceRerollAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task SendNotificationDiceAmountAsync(Guid playerId, CancellationToken cancellationToken = default)
        //{
        //    await _gameHub.Clients.Client(playerId.ToString()).SendAsync("DiceAmount", cancellationToken);
        //}

        //public Task SendNotificationExtraTurnAsync(Domain.Models.Player.Player activePlayer, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SendNotificationChooseTargetOpponentAsync(List<Domain.Models.Player.Player> opponents, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SendNotificationEstablishmentsBonusAsync(List<CardCategory> cardCategories, int bonus, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task SendMessage(string user, string message)
        //{
        //    await _gameHub.Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}