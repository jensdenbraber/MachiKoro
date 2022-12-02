using AutoMapper;
using MachiKoro.Api.Contracts.Game.StartGame;

using MachiKoro.Api.Contracts.Game.StartGame;
using MachiKoro.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

[SignalRHub(path: "/hubs/SignalRNotification")]
public class SignalRNotificationHub : Hub<INotifyPlayerService>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SignalRNotificationHub(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [SignalRMethod(name: "GetGame", SignalRSwaggerGen.Enums.Operation.Get)]
    public async Task<GetGameResponse> GetGame([FromRoute][Required] StartGameRequest request)
    {
        var coreRequest = _mapper.Map<Application.v1.Game.Queries.GetGame.GetGameRequest>(request);

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