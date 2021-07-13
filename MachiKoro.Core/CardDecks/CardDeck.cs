using MachiKoro.Core.Cards.Establishments.Basic;

using System.Collections.Generic;

namespace MachiKoro.Core.CardDecks
{
    public class CardDeck
    {
        private readonly int _maxRevealedCards;
        public readonly Stack<EstablishmentBase> EstablishmentCards;
        public Stack<EstablishmentBase> RevealedCards = new Stack<EstablishmentBase>();

        public CardDeck(Stack<EstablishmentBase> establishmentCards, int maxRevealCards)
        {
            EstablishmentCards = establishmentCards;
            _maxRevealedCards = maxRevealCards;

            for (int i = 0; i < _maxRevealedCards; i++)
            {
                RevealTopCard();
            }
        }

        public void RevealTopCard()
        {
            var establishment = EstablishmentCards.Pop();
            RevealedCards.Push(establishment);
        }
    }
}
