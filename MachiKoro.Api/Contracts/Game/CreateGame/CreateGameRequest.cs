using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.CreateGame;

public record CreateGameRequest
{
    [JsonPropertyName("playerId")]
    public Guid playerId { get; init; }

    [JsonPropertyName("maxNumberOfPlayers")]
    public int MaxNumberOfPlayers { get; init; }

    [JsonPropertyName("expansionType")]
    public ExpansionTypeResponse ExpansionType { get; init; }
}