using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Players.Events
{
    public class PlayerPostDieRollEventArgs : EventArgs
    {
        public List<PlayerChoice> PlayerChoices { get; set; } = new List<PlayerChoice>();
    }
}