using MachiKoro.Application.v1.Game.Queries.GetGame;
using MachiKoro.Domain.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.UnitTests.Game;

[TestFixture]
public class GameQueriesTests
{
    private Mock<INotifyPlayerService> _playerService;
    private Mock<IGamesRepository> _gamesRepository;

    [SetUp]
    public void Initialize()
    {
        _playerService = new Mock<INotifyPlayerService>();
        _gamesRepository = new Mock<IGamesRepository>();
    }

    [TearDown]
    public void VerifyNoOtherCalls()
    {
        _playerService.VerifyNoOtherCalls();
        _gamesRepository.VerifyNoOtherCalls();
    }

    [Test]
    public async Task GetGame_Should_Return_Successfully()
    {
        var game = new Domain.Models.Game.Game
        {
            Id = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713"),
        };

        _gamesRepository.Setup(x => x.GetGameAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(game);

        var request = new GetGameRequest
        {
            GameId = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713")
        };

        var handler = new GetGameRequestHandler(_gamesRepository.Object);
        var result = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.AreEqual(request.GameId, result.Game.Id);

        _gamesRepository.Verify(x => x.GetGameAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task GetGame_Should_Return_Throw_Unsuccessfully()
    {
    }
}