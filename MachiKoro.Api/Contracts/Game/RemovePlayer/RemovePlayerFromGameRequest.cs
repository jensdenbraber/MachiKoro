using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.RemovePlayer
{
    public class RemovePlayerFromGameRequest
    {
        [JsonPropertyName("playerId")]
        public Guid PlayerId { get; set; }

        [JsonPropertyName("gameId")]
        public Guid GameId { get; set; }
    }
}