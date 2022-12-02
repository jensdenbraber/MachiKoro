using MachiKoro.Api.Contracts.Game;
using MachiKoro.Api.Contracts.Game.CreateGame;
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
    public static CreateGameCommand ToCore(this CreateGameRequest createGameRequest)
    {
        return new CreateGameCommand
        {
            PlayerId = createGameRequest.PlayerId,
            MaxNumberOfPlayers = createGameRequest.MaxNumberOfPlayers,
            ExpensionType = createGameRequest.ExpansionType.ToCore()
        };
    }

    public static ChooseRequest ToCore(this Contracts.Game.Choose.ChooseRequest request)
    {
        return new ChooseRequest
        {
            Index = request.Index,
        };
    }

    public static GetGameRequest ToCore(this Contracts.Game.StartGame.GetGameRequest request)
    {
        return new GetGameRequest
        {
            GameId = request.GameId,
        };
    }

    public static AddPlayerToGameCommand ToCore(this Contracts.Game.AddPlayer.AddPlayerToGameRequest request)
    {
        return new AddPlayerToGameCommand
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }

    public static RemovePlayerFromGameCommand ToCore(this Contracts.Game.RemovePlayer.RemovePlayerFromGameRequest request)
    {
        return new RemovePlayerFromGameCommand
        {
            GameId = request.GameId,
            PlayerId = request.PlayerId
        };
    }

    public static DeleteGameCommand ToCore(this Contracts.Game.DeleteGame.DeleteGameRequest request)
    {
        return new DeleteGameCommand
        {
            GameId = request.GameId
        };
    }

    public static StartGameRequest ToCore(this Contracts.Game.StartGame.StartGameRequest request)
    {
        return new StartGameRequest
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
}