using MachiKoro.Domain.Interfaces;
using System;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectStadium : IMajorCardEffect
    {
        public readonly int CoinReward = 2;

        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            // if your turn: collect 2 coins from every opponent
            if (!game.ActivePlayer.Equals(player))
            {
                var payAmount = Math.Min(player.CoinAmount, CoinReward);

                player.CoinAmount -= payAmount;
                game.ActivePlayer.CoinAmount += payAmount;
            }
        }
    }
}