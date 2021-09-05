using FluentAssertions;
using MachiKoro.Application.CardDecks;
using Xunit;

namespace MachiKoro.Application.UnitTests
{
    public class CardDeckTests
    {
        [Fact]
        public void BuildCardDecksBasicGame()
        {
            var cardDecks = CardDeckBuilder.BuildCardDecksBasicGame();

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
