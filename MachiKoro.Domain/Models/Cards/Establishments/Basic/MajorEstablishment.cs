using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.CardEffects.Establishments.Basic.Major;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic
{
    public class MajorEstablishment : EstablishmentBase
    {
        private readonly IMajorCardEffect _majorCardEffect;
        public MajorEstablishment(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IMajorCardEffect majorCardEffect)
            : base(name, cardIcon, activationNumbers, constructionCost, majorCardEffect)
        {
            _majorCardEffect = majorCardEffect;
        }
    }
}
