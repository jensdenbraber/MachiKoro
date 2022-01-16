using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Interfaces;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic
{
    public class SecondayCardEffect : IEstablishmentEffect
    {
        private readonly INotifyPlayerService _playerService;
        public readonly int CoinReward;

        public SecondayCardEffect(INotifyPlayerService playerService, int coinReward)
        {
            _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
            CoinReward = coinReward;
        }

        public async void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
        {
            game.ActivePlayer.CoinAmount += CoinReward;

            await _playerService.SendNotificationPlayerCoinsAsync(game.ActivePlayer, cancellationToken);
        }
    }
}