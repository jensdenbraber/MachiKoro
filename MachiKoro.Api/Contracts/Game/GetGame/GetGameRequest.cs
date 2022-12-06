using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.GetGame;

public record GetGameRequest
{
    [JsonPropertyName("gameId")]
    public Guid GameId { get; init; }
}