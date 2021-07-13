using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core
{
    public interface IGame
    {
        public Player ActivePlayer { get; set; }
        public Queue<Player> Players { get; }
        public Guid Id { get; }

        public void AnalyseTheTurn();

        public List<PlayerChoice> PlayerUpkeep();
        public IEnumerable<Player> Opponents();

        public void StartTheTurn(int diceNumber);

        public void EndTheTurn();
    }
}