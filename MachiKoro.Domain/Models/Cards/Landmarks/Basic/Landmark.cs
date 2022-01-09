using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Domain.Models.Cards.Landmarks.Basic
{
    public class LandMark : Card
    {
        public int CompletionCost { get; }
        public bool IsConstructed { get; set; }
        private readonly ILandmarkEffect _landmarkEffect;

        public LandMark(string name, CardCategory cardIcon, int completionCost, ILandmarkEffect landmarkEffect)
            : base(name, cardIcon)
        {
            CompletionCost = completionCost;
            _landmarkEffect = landmarkEffect;
        }

        public void Construct()
        {
            IsConstructed = true;
        }
    }
}