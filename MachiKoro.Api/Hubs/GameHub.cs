using MachiKoro.Application.v1.Game.Commands.Choices;
using MachiKoro.Application.v1.Services;
using MachiKoro.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

[SignalRHub(path: "/hubs/gameHub")]
public class GameHub : Hub<IGameClient>, IGameClient
{
    private readonly GamesService _gamesService;
    private readonly IHubContext<GameHub, IGameClient> _gameHub;

    public GameHub(GamesService gamesService, IHubContext<GameHub, IGameClient> gameHub)
    {
        _gamesService = gamesService;
        _gameHub = gameHub;
    }

    [SignalRMethod(name: "choice", SignalRSwaggerGen.Enums.Operation.Post)]
    public async Task Choice(Guid gameId, string choice)
    {
        await _gamesService.AnalizeChoiceAsync(gameId, choice, CancellationToken.None);
    }

    [SignalRMethod(name: "constructEstabishment", SignalRSwaggerGen.Enums.Operation.Post)]
    public async Task ConstructEstabishment(Guid gameId, Guid cardId)
    {
        var buyChoice = new BuyChoice
        {
            CardId = cardId,
            ChoiceType = Domain.Enums.ChoiceType.ConstructEstablishment,
            TurnPhase = Domain.Enums.TurnType.Construction
        };

        await _gamesService.PostActionConstructionEstablishmentAsync(gameId, buyChoice, CancellationToken.None);
    }

    [SignalRMethod(name: "constructLandMark", SignalRSwaggerGen.Enums.Operation.Post)]
    public Task ConstructLandMark(Guid gameId, Guid cardId)
    {
        throw new NotImplementedException();
    }

    //[SignalRMethod(name: "nameOfTheMethodCalledOnTheClientSide", Microsoft.OpenApi.Models.OperationType.Post)]
    //public async Task SendMessage(string user, string message)
    //{
    //    await Clients.All.SendAsync("ReceiveMessage", user, message);
    //}

    [SignalRMethod(name: "rollDice", SignalRSwaggerGen.Enums.Operation.Post, summary: "Roll the dices")]
    public async Task RollDice(Guid gameId)
    {
        var diceAmountChoice = new DiceAmountChoice
        {
            DiceAmount = 1,
            ChoiceType = Domain.Enums.ChoiceType.AmountDices,
            TurnPhase = Domain.Enums.TurnType.RollDice
        };

        await _gamesService.PostActionDiceAmountAsync(gameId, diceAmountChoice, CancellationToken.None);
    }

    //[HttpPost(ApiRoutes.Games.Upkeep)]
    //[Consumes("application/json")]
    //public async Task<IActionResult> PlayerUpkeep([FromRoute] Guid gameId, [FromRoute] Guid playerId)
    //{
    //    // execute the players upkeep

    //    throw new NotImplementedException();
    //}

    //[HttpPost(ApiRoutes.Games.RollDice)]
    //[Consumes("application/json")]
    //public async Task<IActionResult> PlayerRollDice([FromRoute] Guid gameId, [FromRoute] Guid playerId)//, DiceOptionsRequest diceOptions)
    //{
    //    throw new NotImplementedException();
    //}
}