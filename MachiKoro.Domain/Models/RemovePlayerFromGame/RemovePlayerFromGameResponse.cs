using System;

namespace MachiKoro.Core.Models.RemovePlayerFromGame
{
    public class RemovePlayerFromGameResponse
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
