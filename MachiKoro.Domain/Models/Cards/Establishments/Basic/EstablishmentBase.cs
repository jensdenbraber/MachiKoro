using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic
{
    public abstract class EstablishmentBase : Card
    {
        public List<int> ActivationNumbers { get; }
        public int ConstructionCost { get; }
        private readonly IEstablishmentEffect _establishmentEffect;

        public EstablishmentBase(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect establishmentEffect)
            : base(name, cardIcon)
        {
            ActivationNumbers = activationNumbers;
            ConstructionCost = constructionCost;
            _establishmentEffect = establishmentEffect;
        }

        public void Activate()
        {
            _establishmentEffect.Activate();
        }
    }
}