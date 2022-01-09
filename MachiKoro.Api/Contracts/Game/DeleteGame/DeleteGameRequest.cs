using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.DeleteGame
{
    public class DeleteGameRequest
    {
        [JsonPropertyName("gameId")]
        public Guid GameId { get; set; }
    }
}