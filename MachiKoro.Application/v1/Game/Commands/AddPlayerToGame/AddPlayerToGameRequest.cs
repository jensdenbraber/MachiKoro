using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.AddPlayerToGame
{
    public class AddPlayerToGameRequest : IRequest<AddPlayerToGameResponse>
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
