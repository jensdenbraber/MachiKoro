using System;
using System.Collections.Generic;

namespace MachiKoro.Api.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public List<Player> Players { get; set; }

        public int MaxNumberOfPlayers { get; set; }
    }
}
