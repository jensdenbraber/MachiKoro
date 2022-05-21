using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.StartGame;

public class StartGameRequest : IRequest<Unit>
{
    public Guid GameId { get; set; }
}