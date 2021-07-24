using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Models
{
    public class GameProfile
    {
        [Key]
        public Guid Id { get; internal set; }

        [Required]
        public int ActivePlayer { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
