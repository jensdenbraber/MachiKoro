using MachiKoro.Domain.Interfaces;
using System;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic
{
    public class RestaurantsCardEffect : IEstablishmentEffect
    {
        public readonly int CoinReward;

        public RestaurantsCardEffect(int coinReward)
        {
            CoinReward = coinReward;
        }

        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
        {
            if (game.ActivePlayer != player)
            {
                var bonus = 0;
                if (player.LandmarkCards.Exists(x => x.Name == "Shopping Mall" && x.IsConstructed))
                {
                    bonus = 1;
                }

                var payAmount = Math.Min(game.ActivePlayer.CoinAmount, CoinReward + bonus);

                player.CoinAmount += payAmount;
                game.ActivePlayer.CoinAmount -= payAmount;
            }
        }
    }
}