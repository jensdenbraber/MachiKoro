using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.RefreshToken;

public record RefreshTokenResponse
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Username { get; init; }
    public string JwtToken { get; init; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; init; }
}