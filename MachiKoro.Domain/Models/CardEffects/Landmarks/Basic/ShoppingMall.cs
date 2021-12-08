using MachiKoro.Core.Interfaces;

namespace MachiKoro.Core.CardEffects.Landmarks.Basic
{
    public class ShoppingMall : ILandmarkEffect
    {
        public void Destroy(IGame game)
        {
            throw new System.NotImplementedException();
        }

        public void Effect(IGame game)
        {
            if(game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Cup || 
                game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Bread)
            {

            }
        }
    }
}
