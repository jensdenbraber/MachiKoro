using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile;

public record GetPlayerProfileRequest
{
    [JsonPropertyName("playerId")]
    public Guid PlayerId { get; init; }
}