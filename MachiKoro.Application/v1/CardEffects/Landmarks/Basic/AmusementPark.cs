using MachiKoro.Application.v1.Dice;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Interfaces;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic;

public class AmusementPark : ILandmarkEffect
{
    private readonly INotifyPlayerService _playerService;

    public AmusementPark(INotifyPlayerService playerService)
    {
        _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
    }

    public async void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        //TODO if throw double with dice take an extra turn
        if (game.ActivePlayer.Equals(player) &&
            game.Dices.IsSame())
        {
            await _playerService.SendNotificationExtraTurnAsync(game.ActivePlayer, cancellationToken);
        }
    }
}