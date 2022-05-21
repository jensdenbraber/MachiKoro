namespace MachiKoro.Application.v1.Responses;

public record AuthSuccessResponse
{
    public string Token { get; init; }

    public string RefreshToken { get; init; }
}