using MachiKoro.Application.v1.Game.Commands.Choices;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Application.v1.Services;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

[SignalRHub(path: "/hubs/GameHub")]
public class GameHub : Hub<IGameClient>, IGameClient
{
    private readonly GamesService _gamesService;
    private readonly IHubContext<GameHub, IGameClient> _gameHub;

    public GameHub(GamesService gamesService, IHubContext<GameHub, IGameClient> gameHub)
    {
        _gamesService = gamesService;
        _gameHub = gameHub;
    }

    [SignalRMethod(name: "Choice", Microsoft.OpenApi.Models.OperationType.Post)]
    public async Task Choice(Guid gameId, string data)
    {
        await _gamesService.AnalizeChoiceAsync(gameId, data, CancellationToken.None);
    }

    [SignalRMethod(name: "ConstructEstabishment", Microsoft.OpenApi.Models.OperationType.Post)]
    public async Task ConstructEstabishment(Guid gameId, Guid cardId)
    {
        BuyChoice buyChoice = new BuyChoice
        {
            CardId = cardId,
            ChoiceType = Domain.Enums.ChoiceType.ConstructEstablishment,
            TurnPhase = Domain.Enums.TurnType.Construction
        };

        await _gamesService.PostActionConstructionEstablishmentAsync(gameId, buyChoice, CancellationToken.None);
    }

    [SignalRMethod(name: "ConstructLandMark", Microsoft.OpenApi.Models.OperationType.Post)]
    public Task ConstructLandMark(Guid gameId, Guid cardId)
    {
        throw new NotImplementedException();
    }

    //[SignalRMethod(name: "nameOfTheMethodCalledOnTheClientSide", Microsoft.OpenApi.Models.OperationType.Post)]
    //public async Task SendMessage(string user, string message)
    //{
    //    await Clients.All.SendAsync("ReceiveMessage", user, message);
    //}

    [SignalRMethod(name: "RollDice", Microsoft.OpenApi.Models.OperationType.Post)]
    public async Task RollDice(Guid gameId)
    {
        DiceAmountChoice diceAmountChoice = new DiceAmountChoice
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