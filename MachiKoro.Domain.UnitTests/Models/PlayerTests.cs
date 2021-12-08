using MachiKoro.Core.TestModelFactory.Models.Player;
using FluentAssertions;
using Xunit;

namespace MachiKoro.Core.UnitTests
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
