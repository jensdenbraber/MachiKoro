using MachiKoro.Core.CardDecks;
using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Models.Game
{
    public class Game
    {
        public Guid GameId { get; set; }
        public int NumberOfTurns { get; set; }
        public int NumberOfOrbits { get; set; }
        public List<CardDeck> CardDecks { get; set; }
        public List<Player> Players { get; set; }
        public Player ActivePlayer { get; set; }
    }
}
