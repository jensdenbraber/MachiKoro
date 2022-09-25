using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic;

public class Restaurants : EstablishmentBase
{
    public Restaurants(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect restaurantsCardEffect)
        : base(name, cardIcon, activationNumbers, constructionCost, restaurantsCardEffect)
    {
    }
}