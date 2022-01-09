using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectTvStation : IMajorCardEffect
    {
        public readonly int CoinReward = 5;

        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            // if your turn: collect 5 coins from chosen opponent

            if (game.ActivePlayer.Equals(player))
            {
                // TODO send game.Opponents to GameHub for client to chose

                int choice = 0;

                game.Opponents[choice].CoinAmount -= CoinReward;
                game.ActivePlayer.CoinAmount += CoinReward;
            }
        }
    }
}