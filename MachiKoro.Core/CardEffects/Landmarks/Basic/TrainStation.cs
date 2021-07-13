using MachiKoro.Core.PlayerChoices.PlayerOptions;
using MachiKoro.Core.Players.Events;
using System;

namespace MachiKoro.Core.CardEffects.Landmarks.Basic
{
    public class TrainStation : ILandmarkEffect, IPlayerUpkeep
    {
        public void Effect(IGame game)
        {
            game.ActivePlayer.OnPlayerUpkeep += ActivePlayer_OnPlayerUpkeep;
        }

        public void Destroy(IGame game)
        {
            game.ActivePlayer.OnPlayerUpkeep -= ActivePlayer_OnPlayerUpkeep;
        }

        public void ActivePlayer_OnPlayerUpkeep(object sender, PlayerUpkeepEventArgs e)
        {
            e.PlayerChoices.Add(new PlayerChoice(new RollDoubleDice()));
        }
    }
}