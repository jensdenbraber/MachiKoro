using MachiKoro.Domain.Interfaces;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic;

public class TrainStation : ILandmarkEffect
{
    private readonly INotifyPlayerService _playerService;

    public TrainStation(INotifyPlayerService playerService)
    {
        _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
    }

    public async void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        //TODO able to throw with 2 dice
        if (game.ActivePlayer.Equals(player))
        {
            // TODO send to GameHub for client to chose for 1 or 2 dice

            await _playerService.SendNotificationDiceAmountAsync(game.ActivePlayer.Id, cancellationToken);
        }
    }
}