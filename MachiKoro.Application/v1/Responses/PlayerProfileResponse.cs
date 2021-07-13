using System;

namespace MachiKoro.Contracts.v1.Responses
{
    public class PlayerProfileResponse
    {
        public Guid PlayerId { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}
