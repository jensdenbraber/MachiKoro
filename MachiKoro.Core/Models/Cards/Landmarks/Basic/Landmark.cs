using MachiKoro.Core.CardEffects.Landmarks.Basic;
using MachiKoro.Core.Interfaces;
using MachiKoro.Utilities;

namespace MachiKoro.Core.Cards.Landmarks.Basic
{
    public class LandMark : Cards.ICard
    {
        public string Name { get; }
        public CardCategory CardIcon { get; }
        public int CompletionCost { get; }
        public bool IsConstructed { get; set; }
        private readonly ILandmarkEffect _landmarkEffectBase;

        public LandMark(string name, CardCategory cardIcon, int completionCost, ILandmarkEffect landmarkEffect)
        {
            Name = name;
            CardIcon = cardIcon;
            CompletionCost = completionCost;
            _landmarkEffectBase = landmarkEffect;
        }

        public void Construct(IGame game)
        {
            IsConstructed = true;
            _landmarkEffectBase.Effect(game);
        }

        public void Destroy(IGame game)
        {
            IsConstructed = false;
            _landmarkEffectBase.Destroy(game);
        }
    }
}