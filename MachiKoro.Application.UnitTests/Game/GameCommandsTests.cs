using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.CardDecks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.UnitTests.Game;

[TestFixture]
public class GameCommandsTests
{
    private Mock<INotifyPlayerService> _playerService;
    private Mock<IGamesRepository> _gamesRepository;
    private Mock<ICardDeckBuilderService> _cardDeckBuilderService;

    [SetUp]
    public void Initialize()
    {
        _playerService = new Mock<INotifyPlayerService>();
        _gamesRepository = new Mock<IGamesRepository>();
        _cardDeckBuilderService = new Mock<ICardDeckBuilderService>();
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
        var cardDecks = new List<CardDeck>();

        _gamesRepository.Setup(x => x.CreateAsync(It.IsAny<Domain.Models.Game.Game>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _cardDeckBuilderService.Setup(x => x.BuildCardDecksBasicGame(4, 4, 2)).Returns(cardDecks);

        var request = new CreateGameCommand
        {
            PlayerId = Guid.NewGuid(),
            ExpensionType = ExpensionType.Basic,
            MaxNumberOfPlayers = 2
        };

        var handler = new CreateGameCommandHandler(_cardDeckBuilderService.Object, _gamesRepository.Object, _playerService.Object);
        var result = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.IsNotEmpty(result.GameId.ToString());

        _cardDeckBuilderService.Verify(x => x.BuildCardDecksBasicGame(4, 4, 2)); 
        _gamesRepository.Verify(x => x.CreateAsync(It.IsAny<Domain.Models.Game.Game>(), It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task CreateGame_Should_Return_Throw_Unsuccessfully()
    {
    }
}