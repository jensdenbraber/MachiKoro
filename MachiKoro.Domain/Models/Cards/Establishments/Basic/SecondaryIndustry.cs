using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic
{
    public class SecondaryIndustryCard : EstablishmentBase
    {
        private readonly SecondayCardEffect _secondayCardEffect;

        public SecondaryIndustryCard(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, SecondayCardEffect cardEffectSeconday)
            : base(name, cardIcon, activationNumbers, constructionCost, cardEffectSeconday)
        {
            _secondayCardEffect = cardEffectSeconday;
        }
    }
}
