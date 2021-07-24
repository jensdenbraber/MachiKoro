using MachiKoro.Core.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Core.Cards.Establishments.Basic
{
    public class Restaurants : EstablishmentBase
    {
        private readonly RestaurantsCardEffect _restaurantsCardEffect;

        public Restaurants(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, RestaurantsCardEffect restaurantsCardEffect)
            : base(name, cardIcon, activationNumbers, constructionCost, restaurantsCardEffect)
        {
            _restaurantsCardEffect = restaurantsCardEffect;
        }
    }
}
