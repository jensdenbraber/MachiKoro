using MachiKoro.Core.CardDecks;
using MachiKoro.Core.CardEffects.Establishments.Basic;
using MachiKoro.Core.CardEffects.Landmarks.Basic;
using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using MachiKoro.Core.Players;
using System;
using System.Collections.Generic;
using Xunit;

namespace MachiKoro.Core.UnitTests
{
    public class GameBasicTest
    {
        [Fact]
        public void InitializeGameBasic()
        {
            var cardDecks = new CardDeckBuilder().BuildCardDecksBasicGame();
            var dices = new List<Dice>()
            {
                new Dice(),
                new Dice()
            };

            var players = new List<Player>();

            var player1Id = new Guid("90C24ED4-39B4-43AC-B4F5-F3A3A2A1B000");

            players.Add(new Player(player1Id, Utilities.PlayerType.Computer, 3,
                new List<EstablishmentBase>()
            {
                new PrimaryIndustry("Wheat Field", Utilities.CardCategory.WHEAT, new List<int>() { 1 }, 1, new PrimaryCardEffect(1)),
                new SecondaryIndustryCard("Bakery", Utilities.CardCategory.BREAD, new List<int>() { 2, 3 }, 1, new SecondayCardEffect(1)),
            },
                new List<LandMark>()
            {
                new LandMark("Train Station", Utilities.CardCategory.TOWER, 4, new TrainStation()),
                new LandMark("Shopping Mall", Utilities.CardCategory.TOWER, 10, new ShoppingMall()),
                new LandMark("Amusement Park", Utilities.CardCategory.TOWER, 16, new AmusementPark()),
                new LandMark("Radio Tower", Utilities.CardCategory.TOWER, 22, new RadioTower()),
            }));
            players.Add(new Player(Guid.NewGuid(), Utilities.PlayerType.Computer, 3,
                new List<EstablishmentBase>()
            {
                new PrimaryIndustry("Wheat Field", Utilities.CardCategory.WHEAT, new List<int>() { 1 }, 1, new PrimaryCardEffect(1)),
                new SecondaryIndustryCard("Bakery", Utilities.CardCategory.BREAD, new List<int>() { 2, 3 }, 1, new SecondayCardEffect(1)),
            },
                new List<LandMark>()
            {
                new LandMark("Train Station", Utilities.CardCategory.TOWER, 4, new TrainStation()),
                new LandMark("Shopping Mall", Utilities.CardCategory.TOWER, 10, new ShoppingMall()),
                new LandMark("Amusement Park", Utilities.CardCategory.TOWER, 16, new AmusementPark()),
                new LandMark("Radio Tower", Utilities.CardCategory.TOWER, 22, new RadioTower()),
            }));            
            
            var game = new Game(players, cardDecks, dices);

            Assert.Equal(player1Id, game.ActivePlayer.Id);

            game.ActivePlayer.ConstructLandmark(new LandMark("Train Station", Utilities.CardCategory.TOWER, 4, new TrainStation()));

            List<PlayerChoice> playerChoicesUpkeep = game.PlayerUpkeep();

            //game.RollDice(playerChoicesUpkeep[0].GetType().IsEquivalentTo(PlayerChoices.PlayerOptions.RollDoubleDice));

            List<PlayerChoice> playerChoicesPostDieRoll = game.PlayerPostDieRoll();

            List<PlayerChoice> playerChoicesMainPhase = game.PlayerMainPhase();

            Assert.Single(playerChoicesUpkeep);

            game.EndTheTurn();

            List<PlayerChoice> playerChoices1 = game.PlayerUpkeep();
            
            Assert.Single(playerChoices1);

        }
    }
}
