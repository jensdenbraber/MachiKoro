using MachiKoro.Api.Contracts.Game;
using MachiKoro.Api.Contracts.Game.CreateGame;
using MachiKoro.Api.Contracts.Game.GetGame;
using MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;
using MachiKoro.Application.v1.Game.Commands.Choose;
using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Application.v1.Game.Commands.DeleteGame;
using MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame;
using MachiKoro.Application.v1.Game.Commands.StartGame;
using MachiKoro.Application.v1.Game.Queries.GetGame;
using MachiKoro.Domain.Enums;

namespace MachiKoro.Api.Mappers;

public static class GameMapper
{
    public static CreateGameCommand ToCore(this CreateGameRequest request)
    {
        return request is null ? null : new CreateGameCommand
        {
            PlayerId = request.PlayerId,
            MaxNumberOfPlayers = request.MaxNumberOfPlayers,
            ExpensionType = request.ExpansionType.ToCore()
        };
    }

    public static ChooseRequest ToCore(this Contracts.Game.Choose.ChooseRequest request)
    {
        return request is null ? null : new ChooseRequest
        {
            Index = request.Index,
        };
    }

    public static Application.v1.Game.Queries.GetGame.GetGameRequest ToCore(this Contracts.Game.GetGame.GetGameRequest request)
    {
        return request is null ? null : new Application.v1.Game.Queries.GetGame.GetGameRequest
        {
            GameId = request.GameId,
        };
    }

    public static AddPlayerToGameCommand ToCore(this Contracts.Game.AddPlayer.AddPlayerToGameRequest request)
    {
        return request is null ? null : new AddPlayerToGameCommand
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }

    public static RemovePlayerFromGameCommand ToCore(this Contracts.Game.RemovePlayer.RemovePlayerFromGameRequest request)
    {
        return request is null ? null : new RemovePlayerFromGameCommand
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }

    public static DeleteGameCommand ToCore(this Contracts.Game.DeleteGame.DeleteGameRequest request)
    {
        return request is null ? null : new DeleteGameCommand
        {
            GameId = request.GameId
        };
    }

    public static StartGameRequest ToCore(this Contracts.Game.StartGame.StartGameRequest request)
    {
        return request is null ? null : new StartGameRequest
        {
            GameId = request.GameId
        };
    }

    public static ExpensionType ToCore(this ExpansionTypeResponse expansionTypeResponse)
    {
        return expansionTypeResponse switch
        {
            ExpansionTypeResponse.Basic => ExpensionType.Basic,
            ExpansionTypeResponse.HarborExpansion => ExpensionType.HarborExpansion,
            _ => throw new System.Exception(),
        };
    }

    public static Contracts.Game.GetGame.GetGameResponse ToApi(this Application.v1.Game.Queries.GetGame.GetGameResponse response)
    {
        return response is null ? null : new Contracts.Game.GetGame.GetGameResponse
        {
            CardDecks = response.Game.CardDecks,
            NumberOfOrbits = response.Game.NumberOfOrbits,
            NumberOfTurns = response.Game.NumberOfTurns,
        };
    }
}