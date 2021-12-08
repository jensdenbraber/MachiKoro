using MachiKoro.Core.CardDecks;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Models.Game
{
    public class Game
    {
        public Guid Id { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
        public int NumberOfTurns { get; set; }
        public int NumberOfOrbits { get; set; }
        public List<CardDeck> CardDecks { get; set; }
        public List<Dice.Dice> Dices { get; set; }
        public Player.Player ActivePlayer { get; set; }
        public List<Player.Player> Players { get; set; }
    }
}
