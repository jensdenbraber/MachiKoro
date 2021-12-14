using System;

namespace MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame
{
    public class RemovePlayerFromGameResponse
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
