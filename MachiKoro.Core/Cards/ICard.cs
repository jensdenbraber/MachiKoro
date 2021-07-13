using MachiKoro.Utilities;

namespace MachiKoro.Core.Cards
{
    public interface ICard
    {
        public string Name { get; }

        public CardCategory CardIcon { get; }
    }
}

