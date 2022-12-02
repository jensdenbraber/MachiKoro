using MachiKoro.Domain.Models.Player;

namespace MachiKoro.Api.Mappers;

public static class PlayerMapper
{
    public static Player ToCore(this MachiKoro.Api.Contracts.Player.GetPlayerProfile.GetPlayerProfileRequest player)
    {
        return new Player
        {
            Id = player.PlayerId
        };
    }
}