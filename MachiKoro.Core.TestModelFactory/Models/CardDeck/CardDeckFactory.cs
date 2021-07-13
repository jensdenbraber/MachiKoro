using MachiKoro.Core.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Core.TestModelFactory.Models.CardDeck
{
    public class CardDeckFactory
    {
        public static Core.CardDecks.CardDeck ValidInstance(int maxRevealedCards)
        {
            Stack<EstablishmentBase> establishmentCards = new Stack<EstablishmentBase>();

            CardDecks.CardDeck cardDeck = new CardDecks.CardDeck(establishmentCards, maxRevealedCards);

            return cardDeck;
        }
    }
}
