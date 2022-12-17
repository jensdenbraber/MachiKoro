using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.CardDecks;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Application.v1.Services;

public class CardDeckService : ICardDeckService
{
    private readonly List<CardDeck> _cardsDecks;

    public CardDeckService(List<CardDeck> cardDecks)
    {
        _cardsDecks = cardDecks;
    }

    public bool RemoveCardFromCardDeck(EstablishmentBase card, out CardDeck cardDeck)
    {
        foreach (var cd in _cardsDecks)
        {
            if (cd.RevealedCards.Remove(card))
            {
                cardDeck = cd;
                return true;
            }
        }

        cardDeck= null;

        return false;
    }

    public EstablishmentBase RevealedNextCard(CardDeck cardDeck)
    {
        var establishmentCard = cardDeck.EstablishmentCards.Pop();
        cardDeck.RevealedCards.Add(establishmentCard);

        return establishmentCard;
    }
}
