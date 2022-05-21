using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.AddPlayer;

public record AddPlayerToGameRequest
{
    [JsonPropertyName("gameId")]
    public Guid GameId { get; init; }

    [JsonPropertyName("playerId")]
    public Guid PlayerId { get; init; }
}