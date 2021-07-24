using MachiKoro.Core.Interfaces;

namespace MachiKoro.Core.CardEffects.Establishments.Basic
{
    public class PrimaryCardEffect : IEstablishmentEffect
    {
        public readonly int GoldReward;

        public PrimaryCardEffect(int goldReward)
        {
            GoldReward = goldReward;
        }

        public void Activate(IGame game)
        {
            game.ActivePlayer.GoldAmount += GoldReward;
        }
    }
}