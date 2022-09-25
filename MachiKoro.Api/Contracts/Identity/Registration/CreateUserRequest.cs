using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.Registration;

public record CreateUserRequest
{
    [JsonPropertyName("userName")]
    public string UserName { get; init; }
    [JsonPropertyName("email")]
    public string Email { get; init; }
    [JsonPropertyName("password")]
    public string Password { get; init; }
}