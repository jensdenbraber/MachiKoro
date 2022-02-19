using FluentAssertions;
using MachiKoro.Application.CardDecks;
using NUnit.Framework;

namespace MachiKoro.Application.UnitTests
{
    public class CardDeckTests
    {
        [Test]
        [Ignore("Ignore a test")]
        public void BuildCardDecksBasicGame()
        {
            var cardDecks = new CardDeckBuilder(null).BuildCardDecksBasicGame();

            cardDecks.Should().HaveCount(3);

            const int totalLowCards = 36;
            const int totalHighCards = 36;
            const int totalMajorCards = 12;

            cardDecks[0].RevealedCards.Count.Should().Be(4);
            (cardDecks[0].EstablishmentCards.Count + cardDecks[0].RevealedCards.Count).Should().Be(totalLowCards);

            cardDecks[1].RevealedCards.Count.Should().Be(4);
            (cardDecks[1].EstablishmentCards.Count + cardDecks[1].RevealedCards.Count).Should().Be(totalHighCards);

            cardDecks[2].RevealedCards.Count.Should().Be(2);
            (cardDecks[2].EstablishmentCards.Count + cardDecks[2].RevealedCards.Count).Should().Be(totalMajorCards);
        }
    }
}