using Microsoft.AspNetCore.SignalR;
using System;
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
    }
}