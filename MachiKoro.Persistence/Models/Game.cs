using MachiKoro.Domain.Enums;
using MachiKoro.Persistence.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [EnumDataType(typeof(ExpensionType))]
        public ExpensionType ExpensionType { get; set; }

        [Required]
        public virtual Guid PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
