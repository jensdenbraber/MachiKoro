using System.ComponentModel;

namespace MachiKoro.Domain.Enums
{
    public enum CardDeckType
    {
        [Description("Classic")]
        Classic = 0,

        [Description("Three decks")]
        ThreeDecks = 1
    }
}