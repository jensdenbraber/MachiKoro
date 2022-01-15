using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface INotifyPlayerService
    {
        //Task SendNotificationToPlayerAsync(Guid playerId, string message, CancellationToken cancellationToken = default);

        //Task SendNotificationToAllPlayersAsync(string message, CancellationToken cancellationToken = default);

        Task SendNotificationDiceRollAsync(object message, CancellationToken cancellationToken);

        Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken);

        Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken);

        Task SendNotificationExtraTurnAsync(Domain.Models.Player.Player activePlayer, CancellationToken cancellationToken);

        Task SendNotificationChooseTargetOpponentAsync(List<Domain.Models.Player.Player> opponents, CancellationToken cancellationToken);

        Task SendNotificationDiceRerollAsync(CancellationToken cancellationToken);

        Task SendNotificationDiceAmountAsync(CancellationToken cancellationToken);

        Task SendNotificationPlayerCoinsAsync(Domain.Models.Player.Player player, CancellationToken cancellationToken);

        Task SendNotificationEstablishmentsBonusAsync(List<CardCategory> cardCategories, int bonus, CancellationToken cancellationToken);

        Task SendNotificationPlayersCoinsAsync(IEnumerable<Domain.Models.Player.Player> players, CancellationToken cancellationToken);

        Task SendNotificationPlayersIncomeAsync(Guid playerId, object message, CancellationToken cancellationToken);

        Task SendNotificationWinnerAsync(Guid playerId, CancellationToken cancellationToken);

        Task SendNotificationTargetAsync(IEnumerable<EstablishmentBase> opponentsTargets, CancellationToken cancellationToken);
    }
}