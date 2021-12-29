using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Establishments.Basic.Major
{
    public class CardEffectTvStation : IMajorCardEffect
    {
        public void Activate(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            // if your turn: collect 5 coins from chosen opponent
            throw new System.NotImplementedException();
        }
    }
}