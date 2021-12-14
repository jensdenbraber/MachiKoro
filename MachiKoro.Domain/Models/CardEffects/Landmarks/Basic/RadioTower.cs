namespace MachiKoro.Domain.Models.CardEffects.Landmarks.Basic
{
    public class RadioTower : ILandmarkEffect
    {
        public void Effect()
        {
            //game.ActivePlayer.OnPlayerPostDieRoll += ActivePlayer_OnPlayerPostDieRoll;
        }

        public void Destroy()
        {
            //game.ActivePlayer.OnPlayerPostDieRoll -= ActivePlayer_OnPlayerPostDieRoll;
        }

        public void ActivePlayer_OnPlayerPostDieRoll()
        {
            //e.PlayerChoices.Add(new PlayerChoice(new RerollDice()));
        }
    }
}