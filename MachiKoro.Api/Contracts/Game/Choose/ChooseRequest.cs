using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.Choose;

public record ChooseRequest
{
    [JsonPropertyName("index")]
    public int Index { get; init; }
}