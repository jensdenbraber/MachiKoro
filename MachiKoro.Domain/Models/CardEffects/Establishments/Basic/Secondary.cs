namespace MachiKoro.Domain.Models.CardEffects.Establishments.Basic
{
    public class SecondayCardEffect : IEstablishmentEffect
    {
        public readonly int GoldReward;

        public SecondayCardEffect(int goldReward)
        {
            GoldReward = goldReward;
        }

        public void Activate()
        {
            //game.ActivePlayer.GoldAmount += GoldReward;
        }
    }
}