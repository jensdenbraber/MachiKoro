using MachiKoro.Core.CardEffects.Establishments.Basic;
using MachiKoro.Core.CardEffects.Landmarks.Basic;
using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Core.TestModelFactory.Models.Player
{
    public class PlayerFactory
    {
        public static Players.Player ValidPlayerInstance()
        {
            var establishmentCards = new List<EstablishmentBase>()
            {
                new PrimaryIndustry("Wheat Field", Utilities.CardCategory.WHEAT, new List<int>() { 1 }, 1, new PrimaryCardEffect(1)),
                new SecondaryIndustryCard("Bakery", Utilities.CardCategory.BREAD, new List<int>() { 2, 3 }, 1, new SecondayCardEffect(1)),
            };

            var landmarkCards = new List<LandMark>()
            {
                new LandMark("Train Station", Utilities.CardCategory.TOWER, 4, new TrainStation()),
                new LandMark("Shopping Mall", Utilities.CardCategory.TOWER, 10, new ShoppingMall()),
                new LandMark("Amusement Park", Utilities.CardCategory.TOWER, 16, new AmusementPark()),
                new LandMark("Radio Tower", Utilities.CardCategory.TOWER, 22, new RadioTower()),
            };

            return new Players.Player(Guid.NewGuid(), Utilities.PlayerType.Computer, 3, establishmentCards, landmarkCards);
        }
    }
}
