using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using MachiKoro.Core.Players.Events;
using MachiKoro.Utilities;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Players
{
    public class Player : IPlayer
    {
        public Guid Id;
        public PlayerType PlayerType;

        private readonly IGame _game;
        public int GoldAmount { get; set; }
        public List<EstablishmentBase> EstablishmentCards = new List<EstablishmentBase>();
        public List<LandMark> LandmarkCards = new List<LandMark>();

        public event EventHandler<PlayerUpkeepEventArgs> OnPlayerUpkeep;
        public event EventHandler<PlayerPostDieRollEventArgs> OnPlayerPostDieRoll;
        public event EventHandler<PlayerMainPhaseEventArgs> OnPlayerMainPhase;

        public Player(Guid id, PlayerType playerType, int goldAmount, List<EstablishmentBase> establishments, List<LandMark> landmarkCards)
        {
            Id = id;
            PlayerType = playerType;
            GoldAmount = goldAmount;
            EstablishmentCards = establishments;
            LandmarkCards = landmarkCards;
        }

        public Player(Guid id, PlayerType playerType, IGame game, int goldAmount, List<EstablishmentBase> establishments, List<LandMark> landmarkCards)
        {
            Id = id;
            PlayerType = playerType;
            _game = game;
            GoldAmount = goldAmount;
            EstablishmentCards = establishments;
            LandmarkCards = landmarkCards;
        }

        public void PlayerUpkeep(IGame game, PlayerUpkeepEventArgs e)
        {
            OnPlayerUpkeep?.Invoke(game, e);
        }

        public void PlayerPostDieRoll(IGame game, PlayerPostDieRollEventArgs e)
        {
            OnPlayerPostDieRoll?.Invoke(game, e);
        }

        public void PlayerMainPhase(IGame game, PlayerMainPhaseEventArgs e)
        {
            OnPlayerMainPhase?.Invoke(game, e);
        }

        public void BuyEstablishment(EstablishmentBase establishment)
        {
            EstablishmentCards.Add(establishment);
        }

        public void ConstructLandmark(LandMark landMark)
        {
            //if (LandmarkCards.Contains(landMark))
            //{
                LandmarkCards.Find(l => l.Name == landMark.Name).Construct(_game);
            //}
        }
        public bool IsLandmarkConstructed(LandMark landMark)
        {
            if(LandmarkCards.Contains(landMark))
            {
                return LandmarkCards.Find(l => l.Name == landMark.Name).IsConstructed;
            }

            return false;
        }
    }
}
