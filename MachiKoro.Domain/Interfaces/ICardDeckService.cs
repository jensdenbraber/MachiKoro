using MachiKoro.Domain.Models.CardDecks;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;

namespace MachiKoro.Domain.Interfaces;

public interface ICardDeckService
{
    bool RemoveCardFromCardDeck(EstablishmentBase card, out CardDeck cardDeck);
    EstablishmentBase RevealedNextCard(CardDeck cardDeck);
}
