using MachiKoro.Domain.Enums;
using System.Text.Json.Serialization;

namespace MachiKoro.Application.v1.Game.Commands.Choices
{
    public class Choice
    {
        [JsonPropertyName("phase")]
        public TurnType TurnPhase { get; set; }

        [JsonPropertyName("type")]
        public ChoiceType ChoiceType { get; set; }
    }
}