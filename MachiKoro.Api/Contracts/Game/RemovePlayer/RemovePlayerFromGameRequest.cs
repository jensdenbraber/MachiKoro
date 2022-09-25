using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.RemovePlayer;

public record RemovePlayerFromGameRequest
{
    [JsonPropertyName("playerId")]
    public Guid PlayerId { get; init; }

    [JsonPropertyName("gameId")]
    public Guid GameId { get; init; }
}