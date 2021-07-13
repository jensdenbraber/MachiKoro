using MachiKoro.Core.CardEffects.Establishments;
using MachiKoro.Core.CardEffects.Establishments.Basic;
using MachiKoro.Utilities;
using System.Collections.Generic;

namespace MachiKoro.Core.Cards.Establishments.Basic
{
    public class SecondaryIndustryCard : EstablishmentBase
    {
        private readonly SecondayCardEffect _secondayCardEffect;

        public SecondaryIndustryCard(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, SecondayCardEffect cardEffectSeconday) 
            : base (name, cardIcon, activationNumbers, constructionCost, cardEffectSeconday)
        {
            _secondayCardEffect = cardEffectSeconday;
        }
    }
}
