using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Models
{
    public class PlayersStatistics
    {
        [Key]
        public Guid Id { get; internal set; }
        
        [Required]
        public int GamesPlayed { get; set; }
        
        [Required]
        public int GamesWon { get; set; }
        
        [Required]
        public int GamesLost { get; set; }

        [Required]
        public virtual PlayerProfile PlayerProfile { get; set; }
        
        [Required]
        public Guid PlayerProfileForeignKey { get; internal set; }
    }
}
