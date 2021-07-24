using MachiKoro.Core.CardDecks;

namespace MachiKoro.Core.TestModelFactory.Models.Game
{
    public class GameFactory
    {
        public static Core.Game.Game ValidInstance(int numberOfPlayers)
        {
            var cardDecks = new CardDeckBuilder().BuildCardDecksBasicGame();

            Core.Game.Game game = new Core.Game.Game(cardDecks);

            return game;
        }
    }
}