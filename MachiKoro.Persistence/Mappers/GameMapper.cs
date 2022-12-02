namespace MachiKoro.Persistence.Mappers;

internal static class GameMapper
{
    internal static Domain.Models.Game.Game ToCore(this Models.Game game)
    {
        return new Domain.Models.Game.Game
        {
            Id = game.Id,
            MaxNumberOfPlayers = game.MaxNumberOfPlayers,
            ExpensionType = game.ExpensionType,
        };
    }

    internal static Models.Game ToPersistence(this Domain.Models.Game.Game game)
    {
        return new Models.Game
        {
            Id = game.Id,
            MaxNumberOfPlayers = game.MaxNumberOfPlayers,
            ExpensionType = game.ExpensionType,
        };
    }
}