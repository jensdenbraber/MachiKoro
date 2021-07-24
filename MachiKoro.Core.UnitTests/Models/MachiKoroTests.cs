using MachiKoro.Core.Players;
using MachiKoro.Core.TestModelFactory.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiKoro.Core.TestModelFactory
{
    public class MachiKoroTests
    {
        private readonly List<Player> players = new List<Player>()
        {
            new Player(Guid.NewGuid(), PlayerType.Computer, 3, null, null),
            new Player(Guid.NewGuid(), PlayerType.Computer, 3, null, null),
            new Player(Guid.NewGuid(), PlayerType.Computer, 3, null, null),
            new Player(Guid.NewGuid(), PlayerType.Computer, 3, null, null)
        };

        [Fact (Skip = "Disabled to due restructure of the program, test not supported at the moment.") ]
        public void MachiKoroNewGameTest()
        {
            //Game game = MachiKoro2.SetupBasicGame(4);

            

            //Assert.Equal(4, game.Players.Count);
            //Assert.Equal(players.First(), game.ActivePlayer);
            //Assert.Equal(3, game.CardDecks.Count);

            //Assert.NotEmpty(game.CardDecks);
            //Assert.Equal(3, game.CardDecks.Count);

            //const int TotalLowCards = 36;
            //const int TotalHighCards = 36;
            //const int TotalMajorCards = 12;

            //Assert.Equal(4, game.CardDecks[0].RevealedCards.Count);
            //Assert.Equal(TotalLowCards, game.CardDecks[0].EstablishmentCards.Count + game.CardDecks[0].RevealedCards.Count);

            //Assert.Equal(4, game.CardDecks[1].RevealedCards.Count);
            //Assert.Equal(TotalHighCards, game.CardDecks[1].EstablishmentCards.Count + game.CardDecks[1].RevealedCards.Count);

            //Assert.Equal(2, game.CardDecks[2].RevealedCards.Count);
            //Assert.Equal(TotalMajorCards, game.CardDecks[2].EstablishmentCards.Count + game.CardDecks[2].RevealedCards.Count);
        }
    }
}
