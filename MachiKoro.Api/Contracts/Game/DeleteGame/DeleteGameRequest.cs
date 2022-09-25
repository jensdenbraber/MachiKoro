using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.DeleteGame;

public record DeleteGameRequest
{
    [JsonPropertyName("gameId")]
    public Guid GameId { get; init; }
}