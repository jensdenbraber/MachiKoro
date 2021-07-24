//using MachiKoro. Core;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MachiKoro.Api
//{
//    public class GameLobby : IGameLobby
//    {
//        /// <summary>
//        /// A collection of active games.
//        /// </summary>
//        private readonly ConcurrentBag<IGame> _activeGames = new ConcurrentBag<IGame>();

//        public void AddGame(IGame game)
//        {
//            _activeGames.Add(game);
//        }

//        public IGame GetGame(Guid gameId)
//        {
//            var game = _activeGames.FirstOrDefault(x => x.Id == gameId);
//            return game;
//        }

//        public void RemoveGame(IGame game)
//        {
//            throw new NotImplementedException();
//            //_activeGames.Add(game);
//        }
//    }
//}
