namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile
{
    public class GetPlayerProfileResponse
    {
        public string UserName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}