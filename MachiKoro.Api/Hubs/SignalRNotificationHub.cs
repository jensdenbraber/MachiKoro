using MachiKoro.Api.Contracts.Game.StartGame;
using MachiKoro.Api.Mappers;
using MachiKoro.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

[SignalRHub(path: "/hubs/SignalRNotification")]
public class SignalRNotificationHub : Hub<INotifyPlayerService>
{
    private readonly IMediator _mediator;

    public SignalRNotificationHub(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [SignalRMethod(name: "GetGame", SignalRSwaggerGen.Enums.Operation.Get)]
    public async Task<GetGameResponse> GetGame([FromRoute][Required] StartGameRequest request)
    {
        var coreRequest = request.ToCore();

        var coreResponse = await _mediator.Send(coreRequest);

        return new GetGameResponse();
    }

    //[SignalRMethod(name: "SendNotificationDiceRollAsync", Microsoft.OpenApi.Models.OperationType.Get)]
    //public async Task SendNotificationDiceRollAsync(string message, CancellationToken cancellationToken = default)
    //{
    //    //await Clients.All.SendAsync("DiceRoll", message);
    //}

    //[SignalRMethod(name: "SendNotificationToAllPlayersAsync", Microsoft.OpenApi.Models.OperationType.Get)]
    //public async Task SendNotificationToAllPlayersAsync(string message, CancellationToken cancellationToken = default)
    //{
    //    throw new NotImplementedException();
    //}

    //[SignalRMethod(name: "SendNotificationToPlayerAsync", Microsoft.OpenApi.Models.OperationType.Get)]
    //public Task SendNotificationToPlayerAsync(Guid playerId, string message, CancellationToken cancellationToken = default)
    //{
    //    throw new NotImplementedException();
    //}
}