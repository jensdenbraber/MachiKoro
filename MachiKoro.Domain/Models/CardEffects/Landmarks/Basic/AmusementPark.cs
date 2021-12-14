namespace MachiKoro.Domain.Models.CardEffects.Landmarks.Basic
{
    public class AmusementPark : ILandmarkEffect
    {
        public void Destroy()
        {
            //game.ActivePlayer.OnPlayerPostDieRoll -= ActivePlayer_OnPlayerPostDieRoll;
        }

        public void Effect()
        {
            //game.ActivePlayer.OnPlayerPostDieRoll += ActivePlayer_OnPlayerPostDieRoll;
        }

        public void ActivePlayer_OnPlayerPostDieRoll()
        {
            //if (game.DiceHelper.IsSame())
            //{
            //    e.
            //}
        }
    }
}