using System.Text.Json.Serialization;

namespace MachiKoro.Application.v1.Game.Commands.Choices;

public class DiceAmountChoice : Choice
{
    [JsonPropertyName("diceAmount")]
    public int DiceAmount { get; set; }
}