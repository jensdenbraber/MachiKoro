namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile;

public record GetPlayerProfileResponse
{
    public string UserName { get; init; }
    public int GamesPlayed { get; init; }
    public int GamesWon { get; init; }
    public int GamesLost { get; init; }
}