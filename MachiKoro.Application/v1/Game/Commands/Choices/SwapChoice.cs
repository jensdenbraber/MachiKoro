using System;
using System.Text.Json.Serialization;

namespace MachiKoro.Application.v1.Game.Commands.Choices
{
    public class SwapChoice : Choice
    {
        [JsonPropertyName("targetACardId")]
        public Guid TargetACardId { get; set; }

        [JsonPropertyName("targetBCardId")]
        public Guid TargetBCardId { get; set; }
    }
}