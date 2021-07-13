using MachiKoro.Core.Players.Events;

namespace MachiKoro.Core.CardEffects.Landmarks.Basic
{
    public class AmusementPark : ILandmarkEffect, IPlayerPostDieRoll
    {
        public void Destroy(IGame game)
        {
            game.ActivePlayer.OnPlayerPostDieRoll -= ActivePlayer_OnPlayerPostDieRoll;
        }

        public void Effect(IGame game)
        {
            game.ActivePlayer.OnPlayerPostDieRoll += ActivePlayer_OnPlayerPostDieRoll;
        }

        public void ActivePlayer_OnPlayerPostDieRoll(object sender, PlayerPostDieRollEventArgs e)
        {
            //if (game.DiceHelper.IsSame())
            //{
            //    e.
            //}
        }
    }
}