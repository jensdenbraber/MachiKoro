using System;
using System.Collections.Generic;
using System.Linq;

namespace MachiKoro.Application.v1.Dice;

public static class DiceHelper
{
    public static int Total(this List<Domain.Models.Dice.Dice> dices)
    {
        return dices.Sum(x => x.PreviousValue);
    }

    public static bool IsSame(this List<Domain.Models.Dice.Dice> dices)
    {
        return dices.Select(x => x.PreviousValue).Distinct().Count() < 2;
    }

    public static int Roll(this Domain.Models.Dice.Dice dice)
    {
        var newValue = new Random().Next(1, dice.Sides);

        dice.PreviousValue = newValue;

        return newValue;
    }

    public static List<int> Roll(this Domain.Models.Dice.Dice dice, int amountDice)
    {
        var lastValues = new List<int>();

        for (int i = 0; i < amountDice; i++)
        {
            lastValues.Add(dice.Roll());
        }

        return lastValues;
    }
}