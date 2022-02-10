using MachiKoro.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; internal set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime StartedDate { get; set; } = DateTime.Now;

        public DateTime FinishedDate { get; set; } = DateTime.Now;

        public int MaxNumberOfPlayers { get; set; }

        [Required]
        [EnumDataType(typeof(ExpensionType))]
        public ExpensionType ExpensionType { get; set; }

        public ICollection<Step> Step { get; set; }

        [Required]
        public ICollection<Player> Players { get; set; }
    }
}