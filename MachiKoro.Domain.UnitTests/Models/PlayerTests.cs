using FluentAssertions;
using MachiKoro.Domain.TestModelFactory.Models.Player;
using Xunit;

namespace MachiKoro.Domain.UnitTests.Models
{
    public class PlayerTests : BaseUnitTest
    {
        [Fact]
        public void InitializePlayer()
        {
            var sut = PlayerFactory.ValidPlayerInstance();

            var errors = Validate(sut);

            errors.Should().BeEmpty();
        }
    }
}
