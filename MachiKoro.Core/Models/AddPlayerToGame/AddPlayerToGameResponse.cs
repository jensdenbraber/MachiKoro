using System;

namespace MachiKoro.Core.Models.AddPlayerToGame
{
    public class AddPlayerToGameResponse
    {
        public Guid? PlayerId { get; set; }
        public Guid? GameId { get; set; }
    }
}
