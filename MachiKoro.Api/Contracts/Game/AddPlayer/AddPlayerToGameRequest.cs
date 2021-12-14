using System;

namespace MachiKoro.Api.Contracts.Game.AddPlayer
{
    public class AddPlayerToGameRequest
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}