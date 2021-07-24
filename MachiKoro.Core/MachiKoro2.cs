using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using MachiKoro.Core.CardEffects.Establishments.Basic;
using MachiKoro.Core.CardEffects.Landmarks.Basic;
using System;
using System.Collections.Generic;
using MachiKoro.Core.CardDecks;
using MachiKoro.Core.Players;
using System.Linq;


namespace MachiKoro.Core
{
    public static class MachiKoro2
    {
        //public static List<Game> GameList = new List<Game>();

        //public static Game SetupBasicGame(int numberOfPlayers)
        //{
        //    var EstablishmentCards = new List<EstablishmentBase>()
        //    {
        //        new PrimaryIndustry("Wheat Field", CardCategory.WHEAT, new List<int>() { 1 }, 1, new PrimaryCardEffect(1)),
        //        new SecondaryIndustryCard("Bakery", CardCategory.BREAD, new List<int>() { 2, 3 }, 1, new SecondayCardEffect(1)),
        //    };

        //    var LandmarkCards = new List<LandMark>()
        //    {
        //        new LandMark("Train Station", CardCategory.TOWER, 4, new TrainStation()),
        //        new LandMark("Shopping Mall", CardCategory.TOWER, 10, new ShoppingMall()),
        //        new LandMark("Amusement Park", CardCategory.TOWER, 16, new AmusementPark()),
        //        new LandMark("Radio Tower", CardCategory.TOWER, 22, new RadioTower()),
        //    };

        //    //var gamePlayers = InitializePlayersBasic(players, EstablishmentCards, LandmarkCards);

        //    var cardDecks = new CardDeckBuilder().BuildCardDecksBasicGame();

        //    var dices = new List<Dice>()
        //    {
        //        new Dice(),
        //        new Dice()
        //    };

        //    var game = new Game(cardDecks, dices);

        //    //var game = new Game(gamePlayers, cardDecks, dices);

        //    GameList.Add(game);

        //    return game;
        //}

        //public static void RemoveGame(Guid gameId)
        //{
        //    GameList.RemoveAll(g => g.Id == gameId);
        //}

        //public static void PlayerJoinGame(Player player, Guid gameId)
        //{
        //    //TODO get game, check is exists
        //    // check if not full/started
        //    // 
        //    GameList.SingleOrDefault(g => g.Id == gameId).AddPlayer(player);
        //}

        //public static void PlayerLeavesGame(Player player, Guid gameId)
        //{
        //    //TODO get game, check is exists
        //    // check if not full/started
        //    // 
        //    GameList.SingleOrDefault(g => g.Id == gameId).RemovePlayer(player);
        //}

        //public static void StartGame(Guid gameId)
        //{
        //    GameList.SingleOrDefault(g => g.Id == gameId).Start();
        //}

        //private static Queue<Player> InitializePlayerBasic(Player player, List<EstablishmentBase> EstablishmentCards, List<LandMark> LandmarkCards)
        //{
        //    var gamePlayers = new Queue<Player>();
            
        //    var p = new Player(player.Id, player.PlayerType, 3, EstablishmentCards, LandmarkCards);

        //    gamePlayers.Enqueue(p);

        //    return gamePlayers;
        //}
    }
}
