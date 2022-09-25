using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.Login;

public record LoginUserResponse
{
    public string UserId { get; init; }
    public string UserName { get; init; }
    public string Token { get; init; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; init; }
}