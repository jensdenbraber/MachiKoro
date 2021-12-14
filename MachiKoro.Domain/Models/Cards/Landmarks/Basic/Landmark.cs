using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.CardEffects.Landmarks.Basic;

namespace MachiKoro.Domain.Models.Cards.Landmarks.Basic
{
    public class LandMark : Card
    {
        public int CompletionCost { get; }
        public bool IsConstructed { get; set; }
        private readonly ILandmarkEffect _landmarkEffectBase;

        public LandMark(string name, CardCategory cardIcon, int completionCost, ILandmarkEffect landmarkEffect)
            : base(name, cardIcon)
        {
            CompletionCost = completionCost;
            _landmarkEffectBase = landmarkEffect;
        }

        public void Construct()
        {
            IsConstructed = true;
            _landmarkEffectBase.Effect();
        }

        public void Destroy()
        {
            IsConstructed = false;
            _landmarkEffectBase.Destroy();
        }
    }
}