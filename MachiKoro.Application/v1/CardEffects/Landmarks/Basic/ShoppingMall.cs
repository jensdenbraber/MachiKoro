using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic
{
    public class ShoppingMall : ILandmarkEffect
    {
        public void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            //TODO increase coin reward on cup and bread cards with 1
            //
            //if (game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Cup ||
            //    game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Bread)
            //{
            //}
        }
    }
}