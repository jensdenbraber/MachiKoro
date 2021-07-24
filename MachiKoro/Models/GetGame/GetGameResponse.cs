using MachiKoro.Core.CardDecks;
using System;
using System.Collections.Generic;

namespace MachiKoro.Api.Models.GetGame
{
    public class GetGameResponse
    {
        public int NumberOfTurns { get; private set; }
        public int NumberOfOrbits { get; private set; }
        public List<CardDeck> CardDecks;
        public List<Guid> PlayersList { get; set; }
    }
}
