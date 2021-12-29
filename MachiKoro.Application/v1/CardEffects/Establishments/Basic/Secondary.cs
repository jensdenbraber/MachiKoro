using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic
{
    public class SecondayCardEffect : IEstablishmentEffect
    {
        public readonly int CoinReward;

        public SecondayCardEffect(int goldReward)
        {
            CoinReward = goldReward;
        }

        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            game.ActivePlayer.CoinAmount += CoinReward;
        }
    }
}