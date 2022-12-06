using MachiKoro.Api.Contracts.Game.GetGame;
using MachiKoro.Api.Controllers.v1;
using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.UnitTests.Game;

[TestFixture]
public class GameTests
{
    private Mock<IMediator> _mockMediator;
    private Mock<ILogger> _mockLogger;

    [SetUp]
    public void SetUp()
    {
        _mockMediator = new Mock<IMediator>();
        _mockLogger = new Mock<ILogger>();
    }

    [TearDown]
    public void TearDown()
    {
        _mockMediator.VerifyNoOtherCalls();
        _mockLogger.VerifyNoOtherCalls();
    }

    [Test]
    public async Task CreateGame_Should_Return_Successfully()
    {
        var createGameResponse = new CreateGameResponse
        {
            GameId = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713"),
        };

        _mockMediator.Setup(x => x.Send(It.IsAny<CreateGameCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(createGameResponse);

        _mockLogger.Setup(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
            ));

        var gameController = new GameController(_mockMediator.Object, _mockLogger.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        var request = new Contracts.Game.CreateGame.CreateGameRequest
        {
            PlayerId = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713"),
            ExpansionType = Contracts.Game.ExpansionTypeResponse.Basic,
            MaxNumberOfPlayers = 2
        };

        var result = (CreatedResult)await gameController.CreateAsync(request);

        Assert.AreEqual(201, result.StatusCode);
        Assert.AreEqual("D84468AC-52A7-4C55-95BF-FB70D589A713", result.Value.ToString().ToUpper());

        _mockMediator.Verify(x => x.Send(It.IsAny<CreateGameCommand>(), It.IsAny<CancellationToken>()));

        _mockLogger.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
        ), Times.Once);
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
        var getGameResponse = new Application.v1.Game.Queries.GetGame.GetGameResponse
        {
            Game = new Domain.Models.Game.Game()
        };

        _mockMediator.Setup(x => x.Send(It.IsAny<Application.v1.Game.Queries.GetGame.GetGameRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(getGameResponse);
        _mockLogger.Setup(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
            ));

        var gameController = new GameController(_mockMediator.Object, _mockLogger.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        var request = new GetGameRequest
        {
            GameId = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713")
        };

        var result = (OkObjectResult)await gameController.GetAsync(request);

        Assert.AreEqual(200, result.StatusCode);

        _mockMediator.Verify(x => x.Send(It.IsAny<Application.v1.Game.Queries.GetGame.GetGameRequest>(), It.IsAny<CancellationToken>()));

        _mockLogger.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
            ), Times.Once);
    }

    [Test]
    public async Task GetGameById_Should_Throw_Game_Not_Found()
    {
        _mockMediator.Setup(x => x.Send(It.IsAny<Application.v1.Game.Queries.GetGame.GetGameRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<Application.v1.Game.Queries.GetGame.GetGameResponse>());

        _mockLogger.Setup(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
            ));

        var gameController = new GameController(_mockMediator.Object, _mockLogger.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        var request = new GetGameRequest
        {
            GameId = Guid.Parse("D84468AC-52A7-4C55-95BF-FB70D589A713")
        };

        var result = (NotFoundObjectResult)await gameController.GetAsync(request);

        Assert.AreEqual(404, result.StatusCode);

        _mockMediator.Verify(x => x.Send(It.IsAny<Application.v1.Game.Queries.GetGame.GetGameRequest>(), It.IsAny<CancellationToken>()));

        _mockLogger.Verify(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
        ), Times.Once);
    }
}