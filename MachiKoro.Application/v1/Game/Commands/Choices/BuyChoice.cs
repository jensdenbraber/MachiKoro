using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Application.v1.Game.Commands.Choices
{
    public class BuyChoice : Choice
    {
        [JsonPropertyName("cardId")]
        public Guid CardId { get; set; }
    }
}