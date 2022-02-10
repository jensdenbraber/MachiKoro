using System.Text.Json.Serialization;

namespace MachiKoro.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnType
    {
        RollDice,
        EarnIncome,
        Construction
    }
}