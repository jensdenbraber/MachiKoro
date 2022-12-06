using MachiKoro.Domain.Interfaces;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic;

public class PrimaryCardEffect : IEstablishmentEffect
{
    private readonly INotifyPlayerService _playerService;
    public readonly int CoinReward;

    public PrimaryCardEffect(INotifyPlayerService playerService, int coinReward)
    {
        _playerService = playerService;
        CoinReward = coinReward;
    }

    public async void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        if (game.ActivePlayer.Equals(player))
        {
            game.ActivePlayer.CoinAmount += CoinReward;

            await _playerService.SendNotificationPlayersIncomeAsync(game.ActivePlayer.Id, game.ActivePlayer.CoinAmount, cancellationToken);
        }
    }
}