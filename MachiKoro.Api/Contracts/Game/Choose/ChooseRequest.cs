using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Game.Choose
{
    public class ChooseRequest
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }
    }
}