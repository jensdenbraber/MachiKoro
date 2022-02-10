using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile
{
    public class GetPlayerProfileRequest
    {
        [JsonPropertyName("playerId")]
        public Guid PlayerId { get; set; }
    }
}