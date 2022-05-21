using MachiKoro.Application.v1.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MachiKoro.Application.UnitTests.Game;

[TestFixture]
public class GameCommandsTests
{
    private Mock<GamesService> _gameServiceMock;

    [SetUp]
    public void Initialize()
    {
        _gameServiceMock = new Mock<GamesService>();
    }

    [TearDown]
    public void VerifyNoOtherCalls()
    {
        _gameServiceMock.VerifyNoOtherCalls();
    }

    [Test]
    public async Task EarnIncomeAsync()
    {
    }
}