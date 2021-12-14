namespace MachiKoro.Domain.Models.CardEffects.Landmarks.Basic
{
    public class TrainStation : ILandmarkEffect
    {
        public void Effect()
        {
            //game.ActivePlayer.OnPlayerUpkeep += ActivePlayer_OnPlayerUpkeep;
        }

        public void Destroy()
        {
            //game.ActivePlayer.OnPlayerUpkeep -= ActivePlayer_OnPlayerUpkeep;
        }

        public void ActivePlayer_OnPlayerUpkeep()
        {
            //e.PlayerChoices.Add(new PlayerChoice(new RollDoubleDice()));
        }
    }
}