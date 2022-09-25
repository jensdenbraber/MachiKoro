namespace MachiKoro.Domain.Models.Dice;

public class Dice
{
    public int PreviousValue { get; set; }
    public readonly int Sides;

    public Dice(int sides = 6)
    {
        Sides = sides;
    }
}