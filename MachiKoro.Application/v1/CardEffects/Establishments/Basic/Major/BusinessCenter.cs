using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectBusinessCenter : IMajorCardEffect
    {
        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            // if your turn: exchange a chosen card with an opponent, may not be of category "Tower"
            throw new System.NotImplementedException();
        }
    }
}