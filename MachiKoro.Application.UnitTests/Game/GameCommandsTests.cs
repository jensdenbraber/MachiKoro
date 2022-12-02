using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Application.v1.Services;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.Game;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.UnitTests.Game;

[TestFixture]
public class GameCommandsTests
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
    public async Task CreateGame_Should_Return_Successfully()
    {
        //_playerService.Setup(x => x.)
        _gamesRepository.Setup(x => x.CreateAsync(It.IsAny<Domain.Models.Game.Game>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var request = new CreateGameCommand
        {
            PlayerId = Guid.NewGuid(),
            ExpensionType = ExpensionType.Basic,
            MaxNumberOfPlayers = 2
        };

        var handler = new CreateGameCommandHandler(_gamesRepository.Object, _playerService.Object);
        var result = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.IsNotEmpty(result.GameId.ToString());
    }

    [Test]
    public async Task CreateGame_Should_Return_Throw_Unsuccessfully()
    {
    }
}