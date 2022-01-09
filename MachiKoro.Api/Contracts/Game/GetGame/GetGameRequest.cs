using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.GetGame
{
    public class GetGameRequest
    {
        [JsonPropertyName("gameId")]
        public Guid GameId { get; set; }
    }
}