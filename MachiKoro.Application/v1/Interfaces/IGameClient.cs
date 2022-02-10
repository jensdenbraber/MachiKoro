using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IGameClient
    {
        Task RollDice(Guid gameId);

        Task Choice(Guid gameId, string choice);

        Task ConstructEstabishment(Guid gameId, Guid cardId);

        Task ConstructLandMark(Guid gameId, Guid cardId);
    }
}