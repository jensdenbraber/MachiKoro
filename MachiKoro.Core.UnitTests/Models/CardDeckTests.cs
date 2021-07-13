using MachiKoro.Core.CardDecks;
using MachiKoro.Core.TestModelFactory.Models.CardDeck;
using Xunit;

namespace MachiKoro.Core.UnitTests
{
    public class CardDeckTests
    {
        [Fact]
        public void BuildCardDecksBasicGame()
        {
            CardDeck cardDeck = CardDeckFactory.ValidInstance(0);

            var cardDeckBuilder = new CardDeckBuilder();
            var cardDecks = cardDeckBuilder.BuildCardDecksBasicGame();

            Assert.NotEmpty(cardDecks);
            Assert.Equal(3, cardDecks.Count);

            const int TotalLowCards = 36;
            const int TotalHighCards = 36;
            const int TotalMajorCards = 12;

            Assert.Equal(4, cardDecks[0].RevealedCards.Count);
            Assert.Equal(TotalLowCards, cardDecks[0].EstablishmentCards.Count + cardDecks[0].RevealedCards.Count);

            Assert.Equal(4, cardDecks[1].RevealedCards.Count);
            Assert.Equal(TotalHighCards, cardDecks[1].EstablishmentCards.Count + cardDecks[1].RevealedCards.Count);

            Assert.Equal(2, cardDecks[2].RevealedCards.Count);
            Assert.Equal(TotalMajorCards, cardDecks[2].EstablishmentCards.Count + cardDecks[2].RevealedCards.Count);
        }
    }
}
