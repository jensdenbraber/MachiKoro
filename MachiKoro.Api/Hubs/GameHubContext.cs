using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Player;
using MachiKoro.Persistence.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs
{
    public class GameHubContext : Application.v1.Interfaces.INotifyPlayerService
    {
        private readonly IHubContext<GameHub> _hubContext;

        public GameHubContext(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }

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

        public Task SendNotificationDiceAmountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
    }
}