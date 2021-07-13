using MachiKoro.Core.PlayerChoices.PlayerOptions;
using MachiKoro.Core.Players.Events;

namespace MachiKoro.Core.CardEffects.Landmarks.Basic
{
    public class RadioTower : ILandmarkEffect, IPlayerPostDieRoll
    {
        public void Effect(IGame game)
        {
            game.ActivePlayer.OnPlayerPostDieRoll += ActivePlayer_OnPlayerPostDieRoll;
        }

        public void Destroy(IGame game)
        {
            game.ActivePlayer.OnPlayerPostDieRoll -= ActivePlayer_OnPlayerPostDieRoll;
        }

        public void ActivePlayer_OnPlayerPostDieRoll(object sender, PlayerPostDieRollEventArgs e)
        {
            e.PlayerChoices.Add(new PlayerChoice(new RerollDice()));
        }
    }
}
