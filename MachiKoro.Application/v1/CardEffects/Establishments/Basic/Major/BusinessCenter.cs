using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using System.Collections.Generic;
using System.Linq;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectBusinessCenter : IMajorCardEffect
    {
        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            // if your turn: exchange a chosen card with an opponent, may not be of category "Tower"

            if (game.ActivePlayer.Equals(player))
            {
                IEnumerable<EstablishmentBase> opponentsTargets = GetAllLegalOpponentsTargets(game);
                IEnumerable<EstablishmentBase> owntargets = GetAllLegalOwnTargets(game);

                IEnumerable<EstablishmentBase> targets = owntargets.Concat(opponentsTargets);

                // TODO send targets to GameHub for client notification
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