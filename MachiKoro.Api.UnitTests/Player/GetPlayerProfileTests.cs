using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MachiKoro.Api.UnitTests.Player;

[TestFixture]
public class GetPlayerProfileTests
{
    private Mock<IMediator> _mockMediator;

    [SetUp]
    public void SetUp()
    {
        _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
    }

    [TearDown]
    public void TearDown()
    {
        _mockMediator.VerifyNoOtherCalls();
    }

    [Test]
    public async Task GetPlayerProfile_Should_Return_Game()
    {
    }

    [Test]
    public async Task GetPlayerProfile_Should_Throw_Game_Not_Found()
    {
    }
}