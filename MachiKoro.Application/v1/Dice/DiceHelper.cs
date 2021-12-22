using System;

namespace MachiKoro.Application.v1.Dice
{
    public static class DiceHelper
    {
        public static int Total()
        {
            throw new NotImplementedException();
        }

        public static bool IsSame()
        {
            throw new NotImplementedException();
        }

        public static int Roll(this Domain.Models.Dice.Dice dice)
        {
            return new Random().Next(1, dice.Sides);
        }
    }
}
