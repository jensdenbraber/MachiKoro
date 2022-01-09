using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface INotifyPlayerService
    {
        //Task SendNotificationToPlayerAsync(Guid playerId, string message, CancellationToken cancellationToken = default);

        //Task SendNotificationToAllPlayersAsync(string message, CancellationToken cancellationToken = default);

        Task SendNotificationDiceRollAsync(object message, CancellationToken cancellationToken = default);

        Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken = default);

        Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken = default);

        Task SendNotificationPlayersIncomeAsync(Guid playerId, object message, CancellationToken cancellationToken = default);
    }
}