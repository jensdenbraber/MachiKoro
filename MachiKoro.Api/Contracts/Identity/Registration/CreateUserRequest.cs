using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.Registration
{
    public record CreateUserRequest
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
