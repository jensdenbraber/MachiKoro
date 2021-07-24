using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.Cards.Landmarks.Basic;
using System;
using System.Collections.Generic;
using MachiKoro.Core.Players;
using System.Linq;


namespace MachiKoro.Core
{
    public static class MachiKoro2
    {
        //public static List<Game> GameList = new List<Game>();


        public static void RemoveGame(Guid gameId)
        {
            //GameList.RemoveAll(g => g.Id == gameId);
        }

        public static void PlayerJoinGame(Player player, Guid gameId)
        {
            //TODO get game, check is exists
            // check if not full/started
            // 
            //GameList.SingleOrDefault(g => g.Id == gameId).AddPlayer(player);
        }

        public static void PlayerLeavesGame(Player player, Guid gameId)
        {
            //TODO get game, check is exists
            // check if not full/started
            // 
            //GameList.SingleOrDefault(g => g.Id == gameId).RemovePlayer(player);
        }

        public static void StartGame(Guid gameId)
        {
            //GameList.SingleOrDefault(g => g.Id == gameId).Start();
        }

        //private static Queue<Player> InitializePlayerBasic(Player player, List<EstablishmentBase> EstablishmentCards, List<LandMark> LandmarkCards)
        //{
        //    var gamePlayers = new Queue<Player>();
            
        //    var p = new Player(player.Id, player.PlayerType, 3, EstablishmentCards, LandmarkCards);

        //    gamePlayers.Enqueue(p);

        //    return gamePlayers;
        //}
    }
}
