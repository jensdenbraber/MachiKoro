using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Extensions;
using MachiKoro.Domain.Models.CardDecks;
using System;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Game
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
        public Player.Player ActivePlayer => Players.Current;

        public List<Player.Player> Opponents
        {
            get
            {
                var opponents = new List<Player.Player>();

                var activePlayer = Players.Current;

                while (Players.Next != activePlayer)
                {
                    Player.Player opponent = Players.MoveNext;

                    opponents.Add(opponent);
                }

                return opponents;
            }
        }

        public CircularList<Player.Player> Players { get; set; }
        public Question Step { get; set; }
    }
}