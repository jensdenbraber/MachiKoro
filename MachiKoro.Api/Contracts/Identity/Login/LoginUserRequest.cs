using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.Login
{
    public record LoginUserRequest
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
