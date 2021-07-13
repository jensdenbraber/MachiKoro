using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Players.Events
{
    public class PlayerMainPhaseEventArgs : EventArgs
    {
        public List<PlayerChoice> PlayerChoices { get; set; } = new List<PlayerChoice>();
    }
}