using MachiKoro.Domain.Interfaces;
using System;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major;

public class CardEffectTvStation : IMajorCardEffect
{
    public readonly int CoinReward = 5;
    private readonly INotifyPlayerService _playerService;

    public CardEffectTvStation(INotifyPlayerService playerService)
    {
        _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
    }

    public async void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        // if your turn: collect 5 coins from chosen opponent

        if (game.ActivePlayer.Equals(player))
        {
            // TODO send game.Opponents to GameHub for client to choose

            await _playerService.SendNotificationChooseTargetOpponentAsync(game.Opponents, cancellationToken);

            int choice = 0;

            var payAmount = Math.Min(game.Opponents[choice].CoinAmount, CoinReward);

            game.Opponents[choice].CoinAmount -= payAmount;
            game.ActivePlayer.CoinAmount += payAmount;
        }
    }
}