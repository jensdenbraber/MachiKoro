using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectBusinessCenter : IMajorCardEffect
    {
        private readonly INotifyPlayerService _playerService;

        public CardEffectBusinessCenter(INotifyPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public async void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
        {
            // if your turn: exchange a chosen card with an opponent, may not be of category "Tower"

            if (game.ActivePlayer.Equals(player))
            {
                IEnumerable<EstablishmentBase> opponentsTargets = GetAllLegalOpponentsTargets(game);
                IEnumerable<EstablishmentBase> ownTargets = GetAllLegalOwnTargets(game);

                await _playerService.SendNotificationTargetAsync(opponentsTargets, cancellationToken);
                await _playerService.SendNotificationTargetAsync(ownTargets, cancellationToken);
            }
        }

        private IEnumerable<EstablishmentBase> GetAllLegalOwnTargets(Domain.Models.Game.Game game)
        {
            IEnumerable<EstablishmentBase> targets = game.ActivePlayer.EstablishmentCards.Where(e => e.CardIcon != Domain.Enums.CardCategory.Tower);

            return targets;
        }

        private IEnumerable<EstablishmentBase> GetAllLegalOpponentsTargets(Domain.Models.Game.Game game)
        {
            IEnumerable<EstablishmentBase> targets = game.Opponents.SelectMany(x => x.EstablishmentCards.Where(e => e.CardIcon != Domain.Enums.CardCategory.Tower));

            return targets;
        }
    }
}