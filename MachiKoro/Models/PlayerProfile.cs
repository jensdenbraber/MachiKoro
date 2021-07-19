using System;

namespace MachiKoro.Api.Models
{
    public class PlayerProfile
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}
