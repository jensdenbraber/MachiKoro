using System;
using System.Threading.Tasks;

namespace MachiKoro.Domain.Interfaces;

public interface IGameClient
{
    Task RollDice(Guid gameId);

    Task Choice(Guid gameId, string choice);

    Task ConstructEstabishment(Guid gameId, Guid cardId);

    Task ConstructLandMark(Guid gameId, Guid cardId);
}