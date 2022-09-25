using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic;

public class MajorEstablishment : EstablishmentBase
{
    public MajorEstablishment(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IMajorCardEffect majorCardEffect)
        : base(name, cardIcon, activationNumbers, constructionCost, majorCardEffect)
    {
    }
}