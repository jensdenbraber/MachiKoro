using System;

namespace MachiKoro.Core.Models.PlayerProfile
{
    public class PlayerProfile
    {
        public Guid PlayerId { get; set; }
        public string UserName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}
