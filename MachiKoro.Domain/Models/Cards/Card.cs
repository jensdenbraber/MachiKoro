using MachiKoro.Domain.Enums;
using System;

namespace MachiKoro.Domain.Models.Cards
{
    public abstract class Card
    {
        public Guid Id { get; }
        public string Name { get; }
        public CardCategory CardIcon { get; }

        protected Card(string name, CardCategory cardIcon)
        {
            Id = Guid.NewGuid();
            Name = name;
            CardIcon = cardIcon;
        }
    }
}