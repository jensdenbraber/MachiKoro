using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.AddPlayer
{
    public class AddPlayerToGameRequest
    {
        [JsonPropertyName("playerId")]
        public Guid PlayerId { get; set; }

        [JsonPropertyName("gameId")]
        public Guid GameId { get; set; }
    }
}