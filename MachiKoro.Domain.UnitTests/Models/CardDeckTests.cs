using FluentAssertions;
using MachiKoro.Core.CardDecks;
using MachiKoro.Core.TestModelFactory.Models.CardDeck;
using System;
using Xunit;

namespace MachiKoro.Core.UnitTests
{
    public class CardDeckTests
    {
        [Fact]
        public void BuildCardDeck()
        {
            var id = Guid.NewGuid();

            CardDeck cardDeck = CardDeckFactory.ValidInstance(id);

            cardDeck.Id.Should().Be(id);
            cardDeck.MaxRevealedCards.Should().Be(0);
            cardDeck.RevealedCards.Count.Should().Be(0);
            cardDeck.EstablishmentCards.Count.Should().Be(0);
        }
    }
}
