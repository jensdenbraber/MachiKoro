using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.CardDecks
{
    public class CardDeck
    {
        public Guid Id { get; set; }
        public int MaxRevealedCards { get; }
        public Stack<EstablishmentBase> EstablishmentCards { get; set; }
        public List<EstablishmentBase> RevealedCards { get; set; }

        public CardDeck(Guid id, Stack<EstablishmentBase> establishmentCards, List<EstablishmentBase> revealedCards, int maxRevealCards)
        {
            Id = id;
            EstablishmentCards = establishmentCards;
            RevealedCards = revealedCards;
            MaxRevealedCards = maxRevealCards;
        }
    }
}