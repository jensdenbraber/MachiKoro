using System;

namespace MachiKoro.Api.Contracts.Game.RemovePlayer
{
    public class RemovePlayerFromGameRequest
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}