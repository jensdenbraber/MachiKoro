using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

//public class SignalRNotificationHubContext : Application.v1.Interfaces.INotifyPlayerService
//{
//    private readonly IHubContext<SignalRNotificationHub> _hubContext;

//    public SignalRNotificationHubContext(IHubContext<SignalRNotificationHub> hubContext)
//    {
//        _hubContext = hubContext;
//    }

//    public async Task SendNotificationDiceRollAsync(string message, CancellationToken cancellationToken = default)
//    {
//        await _hubContext.Clients.All.SendAsync("DiceRoll", message, cancellationToken);
//    }

//    public async Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid playerId, string message, CancellationToken cancellationToken = default)
//    {
//        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("ConstructionEstablishmentsOptions", message, cancellationToken);
//    }

//    public async Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, string message, CancellationToken cancellationToken = default)
//    {
//        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("ConstructionLandmarksOptions", message, cancellationToken);
//    }

//    public async Task SendNotificationPlayersIncomeAsync(Guid playerId, string message, CancellationToken cancellationToken = default)
//    {
//        await _hubContext.Clients.Client(playerId.ToString()).SendAsync("Income", message, cancellationToken);
//    }
//}