namespace MachiKoro.Core.Cards
{
    public abstract class Card
    {
        public string Name { get; }
        public CardCategory CardIcon { get; }

        protected Card(string name, CardCategory cardIcon)
        {
            Name = name;
            CardIcon = cardIcon;
        }
    }
}
