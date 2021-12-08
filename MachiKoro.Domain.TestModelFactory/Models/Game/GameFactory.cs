using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Core.TestModelFactory.Models.Game
{
    public class GameFactory
    {
        public static Core.Models.Game.Game ValidInstance()
        {
            Core.Models.Game.Game game = new Core.Models.Game.Game();

            return game;
        }
    }
}
