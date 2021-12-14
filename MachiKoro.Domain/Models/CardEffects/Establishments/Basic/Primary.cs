namespace MachiKoro.Domain.Models.CardEffects.Establishments.Basic
{
    public class PrimaryCardEffect : IEstablishmentEffect
    {
        public readonly int GoldReward;

        public PrimaryCardEffect(int goldReward)
        {
            GoldReward = goldReward;
        }

        public void Activate()
        {
            //game.ActivePlayer.GoldAmount += GoldReward;
        }
    }
}