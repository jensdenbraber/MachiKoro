using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Interfaces;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic;

public class RadioTower : ILandmarkEffect
{
    private readonly INotifyPlayerService _playerService;

    public RadioTower(INotifyPlayerService playerService)
    {
        _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
    }

    public async void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        //TODO choose if you want to reroll the dice for this turn

        if (game.ActivePlayer.Equals(player))
        {
            // TODO send to GameHub for client to choose for reroll

            await _playerService.SendNotificationDiceRerollAsync(cancellationToken);
        }
    }
}