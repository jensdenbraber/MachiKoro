using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Domain.TestModelFactory.Models.CardDeck;

public class CardDeckFactory
{
    public static Domain.Models.CardDecks.CardDeck ValidInstance(Guid id, int maxRevealedCards = 0)
    {
        var establishmentCards = new Stack<EstablishmentBase>();
        var revealedEstablishmentCards = new List<EstablishmentBase>();

        var cardDeck = new Domain.Models.CardDecks.CardDeck(id, establishmentCards, revealedEstablishmentCards, maxRevealedCards);

        return cardDeck;
    }
}