﻿using MachiKoro.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachiKoro.Data.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; internal set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime StartedDate { get; set; }

        public DateTime FinishedDate { get; set; }

        [Required]
        [EnumDataType(typeof(ExpensionType))]
        public ExpensionType ExpensionType { get; set; }

        [Required]
        public virtual ICollection<Player> Players { get; set; }
    }
}