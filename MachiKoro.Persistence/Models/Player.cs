﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachiKoro.Persistence.Models;

public class Player
{
    [Key]
    public Guid Id { get; internal set; }

    public Guid UserId { get; internal set; }

    //[ForeignKey(nameof(Id))]
    //public Guid PlayerId { get; set; }

    //    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    //    [Required(ErrorMessage = "Name is required")]
    //    public string UserName { get; set; }

    //    [Required]
    //    public virtual PlayerProfile PlayerProfile { get; set; }

    //    //public virtual ICollection<Game> HistoryGames { get; set; }

    public ICollection<Step> Steps { get; set; }

    [Required]
    public ICollection<Game> Games { get; set; }

    public ICollection<GamePlayer> GamePlayers { get; set; }
}