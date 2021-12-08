using MachiKoro.Core.Interfaces;

namespace MachiKoro.Core.CardEffects.Landmarks.Basic
{
    public interface ILandmarkEffect
    {
        public void Effect(IGame game);
        public void Destroy(IGame game);
    }
}