using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.AddPlayer
{
    public class AddPlayerToGameRequest
    {
        [JsonPropertyName("gameId")]
        public Guid GameId { get; set; }

        [JsonPropertyName("playerId")]
        public Guid PlayerId { get; set; }
    }
}