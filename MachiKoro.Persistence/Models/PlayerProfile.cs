using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachiKoro.Persistence.Models
{
    public class PlayerProfile
    {
        [Key]
        public Guid Id { get; internal set; }

        [Required]
        public virtual Player Player { get; set; }

        [Required]
        public virtual PlayersStatistics PlayersStatistics { get; set; }

        [Required]
        public Guid PlayerForeignKey { get; internal set; }

        //public virtual ICollection<Game> HistoryGames { get; set; }
    }
}
