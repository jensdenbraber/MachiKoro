using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic
{
    public class SecondaryIndustryCard : EstablishmentBase
    {
        public SecondaryIndustryCard(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect cardEffectSeconday)
            : base(name, cardIcon, activationNumbers, constructionCost, cardEffectSeconday)
        {
        }
    }
}