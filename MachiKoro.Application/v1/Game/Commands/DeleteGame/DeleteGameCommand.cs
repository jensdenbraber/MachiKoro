using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.DeleteGame;

public class DeleteGameCommand : IRequest<DeleteGameResponse>
{
    public Guid GameId { get; set; }
}