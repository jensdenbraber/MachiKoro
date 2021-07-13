namespace MachiKoro.Core.CardEffects.Establishments.Basic
{
    public class SecondayCardEffect : IEstablishmentEffect
    {
        public readonly int GoldReward;

        public SecondayCardEffect(int goldReward)
        {
            GoldReward = goldReward;
        }

        public void Activate(IGame game)
        {
            game.ActivePlayer.GoldAmount += GoldReward;
        }
    }
}