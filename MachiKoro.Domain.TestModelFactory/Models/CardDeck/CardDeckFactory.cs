using MachiKoro.Core.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.TestModelFactory.Models.CardDeck
{
    public class CardDeckFactory
    {
        public static CardDecks.CardDeck ValidInstance(Guid id, int maxRevealedCards = 0)
        {
            var establishmentCards = new Stack<EstablishmentBase>();
            var revealedEstablishmentCards = new Stack<EstablishmentBase>();

            var cardDeck = new CardDecks.CardDeck(id, establishmentCards, revealedEstablishmentCards, maxRevealedCards);

            return cardDeck;
        }
    }
}
