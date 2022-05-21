using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.RefreshToken;

public record RefreshTokenRequest
{
    [JsonPropertyName("token")]
    public string Token { get; init; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; init; }
}