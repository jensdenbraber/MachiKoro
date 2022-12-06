using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Domain.Interfaces;

public interface INotifyPlayerService
{
    Task SendNotificationDiceRollAsync(object message, CancellationToken cancellationToken);

    Task SendNotificationConstructionEstablishmentsOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken);

    Task SendNotificationConstructionLandmarksOptionsAsync(Guid playerId, object message, CancellationToken cancellationToken);

    Task SendNotificationExtraTurnAsync(Models.Player.Player activePlayer, CancellationToken cancellationToken);

    Task SendNotificationChooseTargetOpponentAsync(List<Models.Player.Player> opponents, CancellationToken cancellationToken);

    Task SendNotificationDiceRerollAsync(CancellationToken cancellationToken);

    Task SendNotificationDiceAmountAsync(Guid playerId, CancellationToken cancellationToken);

    Task SendNotificationPlayerCoinsAsync(Models.Player.Player player, CancellationToken cancellationToken);

    Task SendNotificationEstablishmentsBonusAsync(List<CardCategory> cardCategories, int bonus, CancellationToken cancellationToken);

    Task SendNotificationPlayersCoinsAsync(IEnumerable<Models.Player.Player> players, CancellationToken cancellationToken);

    Task SendNotificationPlayersIncomeAsync(Guid playerId, object message, CancellationToken cancellationToken);

    Task SendNotificationWinnerAsync(Guid playerId, CancellationToken cancellationToken = default);

    Task SendNotificationTargetAsync(IEnumerable<EstablishmentBase> opponentsTargets, CancellationToken cancellationToken);

    Task StartGame(string game);
}