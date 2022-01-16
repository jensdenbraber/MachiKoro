using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.CreateGame
{
    public record CreateGameRequest
    {
        [JsonPropertyName("maxNumberOfPlayers")]
        public int MaxNumberOfPlayers { get; set; }

        [JsonPropertyName("expensionType")]
        public ExpensionTypeResponse ExpensionType { get; set; }
    }
}