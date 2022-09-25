using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.StartGame;

public record GetGameRequest
{
    [JsonPropertyName("gameId")]
    public Guid GameId { get; init; }
}