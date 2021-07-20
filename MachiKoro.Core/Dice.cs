﻿using System;

namespace MachiKoro.Core
{
    public class Dice
    {
        public readonly int Sides;
        public Dice(int sides = 6)
        {
            Sides = sides;
        }

        public int Roll()
        {
            return new Random().Next(1, Sides);
        }
    }
}