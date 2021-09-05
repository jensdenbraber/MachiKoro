using MachiKoro.Core.CardEffects.Establishments.Basic;
using MachiKoro.Core.Interfaces;
using System.Collections.Generic;

namespace MachiKoro.Core.Cards.Establishments.Basic
{
    public abstract class EstablishmentBase : Card
    {
        public List<int> ActivationNumbers { get; }
        public int ConstructionCost { get; }
        private readonly IEstablishmentEffect _establishmentEffect;
       
        public EstablishmentBase(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect establishmentEffect)
            :base(name, cardIcon)
        {
            ActivationNumbers = activationNumbers;
            ConstructionCost = constructionCost;
            _establishmentEffect = establishmentEffect;
        }

        public void Activate(IGame game)
        {
            _establishmentEffect.Activate(game);
        }
    }
}