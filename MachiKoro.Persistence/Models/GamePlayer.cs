using System;

namespace MachiKoro.Persistence.Models;

public class GamePlayer
{
    public Guid GamesId { get; set; }
    public Game Game { get; set; }

    public Guid PlayersId { get; set; }
    public Player Player { get; set; }
}