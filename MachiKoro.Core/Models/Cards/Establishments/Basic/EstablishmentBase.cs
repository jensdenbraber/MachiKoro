using MachiKoro.Core.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Core.Cards.Establishments.Basic
{
    public abstract class EstablishmentBase : MachiKoro.Core.Cards.ICard
    {
        private readonly IEstablishmentEffect _establishmentEffect;
        public string Name { get; }
        public CardCategory CardIcon { get; }
        public List<int> ActivationNumbers { get; }
        public int ConstructionCost { get; }
       
        public EstablishmentBase(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect establishmentEffect)
        {
            Name = name;
            CardIcon = cardIcon;
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