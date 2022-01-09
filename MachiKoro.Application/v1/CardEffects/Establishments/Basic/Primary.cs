using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic
{
    public class PrimaryCardEffect : IEstablishmentEffect
    {
        public readonly int CoinReward;

        public PrimaryCardEffect(int coinReward)
        {
            CoinReward = coinReward;
        }

        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            if (game.ActivePlayer.Equals(player))
            {
                game.ActivePlayer.CoinAmount += CoinReward;
            }
        }
    }
}