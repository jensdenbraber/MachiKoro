using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using MachiKoro.Core.Players.Events;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Players
{
    public interface IPlayer
    {
        int GoldAmount { get; set; }
        public void BuyEstablishment(EstablishmentBase establishment);
        public void ConstructLandmark(LandMark landMark);
        public bool IsLandmarkConstructed(LandMark landMark);

        public event EventHandler<PlayerUpkeepEventArgs> OnPlayerUpkeep;
        public event EventHandler<PlayerPostDieRollEventArgs> OnPlayerPostDieRoll;
        public event EventHandler<PlayerMainPhaseEventArgs> OnPlayerMainPhase;

        public void PlayerUpkeep(IGame game, PlayerUpkeepEventArgs e);
        public void PlayerPostDieRoll(IGame game, PlayerPostDieRollEventArgs e);
        public void PlayerMainPhase(IGame game, PlayerMainPhaseEventArgs e);
    }
}
