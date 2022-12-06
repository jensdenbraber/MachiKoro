using MachiKoro.Domain.Models.CardDecks;
using System;
using System.Collections.Generic;

namespace MachiKoro.Api.Contracts.Game.GetGame;

public record GetGameResponse
{
    public int NumberOfTurns { get; init; }
    public int NumberOfOrbits { get; init; }
    public List<CardDeck> CardDecks { get; init; }
    public List<Guid> PlayersList { get; init; }
}