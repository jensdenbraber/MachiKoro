using System;
using System.Collections.Generic;

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

        public static List<int> Roll(this Domain.Models.Dice.Dice dice, int amountDice)
        {
            var list = new List<int>();

            for (int i = 0; i < amountDice; i++)
            {
                list.Add(dice.Roll());
            }

            return list;
        }
    }
}