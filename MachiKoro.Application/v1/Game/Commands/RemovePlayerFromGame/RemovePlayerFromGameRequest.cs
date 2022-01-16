using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame
{
    public class RemovePlayerFromGameRequest : IRequest<RemovePlayerFromGameResponse>
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
