using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MachiKoro.Api.UnitTests.Game;

[TestFixture]
public class GameTests
{
    private Mock<IMediator> _mockMediator;
    private Mock<HttpRequest> _mockHttpRequest;

    [SetUp]
    public void SetUp()
    {
        _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
        _mockHttpRequest = new Mock<HttpRequest>(MockBehavior.Strict);
    }

    [TearDown]
    public void TearDown()
    {
        _mockMediator.VerifyNoOtherCalls();
    }

    [Test]
    public async Task CreateGame_Should_Return_Successfully()
    {
    }

    [Test]
    public async Task CreateGame_Should_Return_Throw_Unsuccessfully()
    {
    }

    [Test]
    public async Task GetAllGames_Should_Return_Games()
    {
    }

    [Test]
    public async Task GetAllGames_Should_Throw_Games_Not_Found()
    {
    }

    [Test]
    public async Task GetGameById_Should_Return_Game()
    {
    }

    [Test]
    public async Task GetGameById_Should_Throw_Game_Not_Found()
    {
    }
}