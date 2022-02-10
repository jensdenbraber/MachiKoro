using System.Text.Json.Serialization;

namespace MachiKoro.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChoiceType
    {
        AmountDices,
        ConstructEstablishment,
        ConstructLandmark,
        Swap
    }
}