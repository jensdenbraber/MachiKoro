using MachiKoro.Core.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.CardDecks
{
    public class CardDeck
    {
        public Guid Id { get; set;  }
        public int MaxRevealedCards { get; }
        public Stack<EstablishmentBase> EstablishmentCards { get; set; }
        public Stack<EstablishmentBase> RevealedCards { get; set; }

        public CardDeck(Guid id, Stack<EstablishmentBase> establishmentCards, Stack<EstablishmentBase> revealedCards, int maxRevealCards)
        {
            Id = id;
            EstablishmentCards = establishmentCards;
            RevealedCards = revealedCards;
            MaxRevealedCards = maxRevealCards;
        }
    }
}
