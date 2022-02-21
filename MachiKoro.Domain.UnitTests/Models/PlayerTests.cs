using FluentAssertions;
using MachiKoro.Domain.TestModelFactory.Models.Player;
using NUnit.Framework;

namespace MachiKoro.Domain.UnitTests.Models
{
    public class PlayerTests : BaseUnitTest
    {
        [Test]
        [Ignore("Ignore a test")]
        public void InitializePlayer()
        {
            var sut = PlayerFactory.ValidPlayerInstance();

            var errors = Validate(sut);

            errors.Should().BeEmpty();
        }
    }
}