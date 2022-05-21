using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;

public class AddPlayerToGameCommand : IRequest<AddPlayerToGameResponse>
{
    public Guid PlayerId { get; set; }
    public Guid GameId { get; set; }
}