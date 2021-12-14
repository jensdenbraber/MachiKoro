using System;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Dice
{
    public class DiceHelper
    {
        private static IEnumerable<Dice> _dices;

        public DiceHelper(List<Dice> dices)
        {
            _dices = dices;
        }

        public static int Total()
        {
            throw new NotImplementedException();
        }

        public static bool IsSame()
        {
            throw new NotImplementedException();
        }
    }
}
