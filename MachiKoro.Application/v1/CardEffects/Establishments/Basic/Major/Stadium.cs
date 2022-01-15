using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Interfaces;
using System;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectStadium : IMajorCardEffect
    {
        private readonly INotifyPlayerService _playerService;
        public readonly int CoinReward = 2;

        public CardEffectStadium(INotifyPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public async void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
        {
            // if your turn: collect 2 coins from every opponent
            if (game.ActivePlayer.Equals(player))
            {
                foreach (var opponent in game.Opponents)
                {
                    var payAmount = Math.Min(opponent.CoinAmount, CoinReward);

                    opponent.CoinAmount -= payAmount;
                    game.ActivePlayer.CoinAmount += payAmount;
                }

                await _playerService.SendNotificationPlayersCoinsAsync(game.Players, cancellationToken);
            }
        }
    }
}