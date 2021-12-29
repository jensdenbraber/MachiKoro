using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic
{
    public class PrimaryIndustry : EstablishmentBase
    {
        public PrimaryIndustry(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect primaryCardEffect)
            : base(name, cardIcon, activationNumbers, constructionCost, primaryCardEffect)
        {
        }
    }
}