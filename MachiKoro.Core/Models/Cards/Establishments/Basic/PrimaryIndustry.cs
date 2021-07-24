using MachiKoro.Core.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Core.Cards.Establishments.Basic
{
    public class PrimaryIndustry : EstablishmentBase
    {
        public readonly PrimaryCardEffect _primaryCardEffect;

        public PrimaryIndustry(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, PrimaryCardEffect primaryCardEffect)
            : base(name, cardIcon, activationNumbers, constructionCost, primaryCardEffect)
        {
            _primaryCardEffect = primaryCardEffect;
        }
    }
}
