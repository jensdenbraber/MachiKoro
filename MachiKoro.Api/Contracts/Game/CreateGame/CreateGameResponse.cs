using System;

namespace MachiKoro.Api.Contracts.Game.CreateGame;

public record CreateGameResponse
{
    public Guid GameId { get; init; }
}