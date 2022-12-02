using MachiKoro.Domain.Models.Player;

namespace MachiKoro.Persistence.Mappers;

internal static class PlayerMapper
{
    internal static Player ToCore(this Models.Player player)
    {
        return new Player
        {
            Id = player.Id,
        };
    }

    internal static Models.Player ToPersistence(this Player player)
    {
        return new Models.Player
        {
            Id = player.Id,
        };
    }
}