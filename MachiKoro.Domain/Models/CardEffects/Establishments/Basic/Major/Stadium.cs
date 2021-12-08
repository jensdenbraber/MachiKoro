using MachiKoro.Core.Interfaces;

namespace MachiKoro.Core.CardEffects.Establishments.Basic.Major
{
    public class CardEffectStadium : IMajorCardEffect
    {
        public void Activate(IGame game)
        {
            int goldReward = 0;

            foreach (var opponent in game.Opponents())
            {
                if (opponent.GoldAmount == 0)
                {
                    continue;
                }
                else if (opponent.GoldAmount == 1)
                {
                    opponent.GoldAmount = 0;
                    goldReward++;
                }
                else
                {
                    opponent.GoldAmount -= 2;
                    goldReward += 2;
                }
            }

            game.ActivePlayer.GoldAmount += goldReward;
        }
    }
}