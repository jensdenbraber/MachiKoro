using MachiKoro.Core.Cards.Establishments.Basic;
using MachiKoro.Core.CardEffects.Establishments.Basic;
using System.Collections.Generic;

namespace MachiKoro.Core.CardDecks
{
    public class CardDeckBuilder
    {
        private readonly List<CardDeck> CardDecks = new List<CardDeck>();
        private void BuildCardDeckLowBasicGame(int numberOfRevealedCards)
        {
            var establishments = new Stack<EstablishmentBase>();

            for (int i = 0; i < 6; i++)
            {
                var wheatField = new PrimaryIndustry("Wheat Field", Utilities.CardCategory.WHEAT, new List<int>() { 1 }, 1, new PrimaryCardEffect(1));
                var ranch = new PrimaryIndustry("Ranch", Utilities.CardCategory.COW, new List<int>() { 2 }, 1, new PrimaryCardEffect(1));
                var forest = new PrimaryIndustry("Forest", Utilities.CardCategory.GEAR, new List<int>() { 5 }, 3, new PrimaryCardEffect(1));

                var bakery = new SecondaryIndustryCard("Bakery", Utilities.CardCategory.BREAD, new List<int>() { 2, 3 }, 1, new SecondayCardEffect(1));
                var convenienceStore = new SecondaryIndustryCard("Convenience Store", Utilities.CardCategory.BREAD, new List<int>() { 4 }, 2, new SecondayCardEffect(3));

                var restaurants = new Restaurants("Cafe", Utilities.CardCategory.CUP, new List<int>() { 3 }, 3, new RestaurantsCardEffect(1));

                establishments.Push(wheatField);
                establishments.Push(ranch);
                establishments.Push(forest);
                establishments.Push(bakery);
                establishments.Push(convenienceStore);
                establishments.Push(restaurants);
            }

            var cardDeck = new CardDeck(establishments, numberOfRevealedCards);

            CardDecks.Add(cardDeck);
        }

        private void BuildCardDeckHighBasicGame(int revealedCards)
        {
            var establishments = new Stack<EstablishmentBase>();

            for (int i = 0; i < 6; i++)
            {
                var mine = new PrimaryIndustry("Mine", Utilities.CardCategory.GEAR, new List<int>() { 9 }, 6, new PrimaryCardEffect(5));
                var appleOrchard = new PrimaryIndustry("Apple Orchard", Utilities.CardCategory.WHEAT, new List<int>() { 10 }, 3, new PrimaryCardEffect(3));

                var cheeseFactory = new SecondaryIndustryCard("Cheese Factory", Utilities.CardCategory.FACTORY, new List<int>() { 7 }, 5, new SecondayCardEffect(3));
                var furnitureFactory = new SecondaryIndustryCard("Furniture Factory", Utilities.CardCategory.FACTORY, new List<int>() { 8 }, 3, new SecondayCardEffect(3));
                var fruitAndVegetableMarket = new SecondaryIndustryCard("Fruit and Vegetable Market", Utilities.CardCategory.FRUIT, new List<int>() { 11, 12 }, 2, new SecondayCardEffect(3));

                var familyRestaurant = new Restaurants("Family Restaurant", Utilities.CardCategory.CUP, new List<int>() { 9, 10 }, 3, new RestaurantsCardEffect(2));


                establishments.Push(mine);
                establishments.Push(appleOrchard);
                establishments.Push(cheeseFactory);
                establishments.Push(furnitureFactory);
                establishments.Push(fruitAndVegetableMarket);
                establishments.Push(familyRestaurant);
            }

            var cardDeck = new CardDeck(establishments, revealedCards);

            CardDecks.Add(cardDeck);
        }

        private void BuildCardDeckMajorBasicGame(int revealedCards)
        {
            var establishments = new Stack<EstablishmentBase>();

            for (int i = 0; i < 4; i++)
            {
                var stadium = new MajorEstablishment("Stadium", Utilities.CardCategory.TOWER, new List<int>() { 6 }, 6, new CardEffects.Establishments.Basic.Major.CardEffectStadium());
                var tvStation = new MajorEstablishment("TV Station", Utilities.CardCategory.TOWER, new List<int>() { 6 }, 7, new CardEffects.Establishments.Basic.Major.CardEffectStadium());
                var businessCenter = new MajorEstablishment("Business Center", Utilities.CardCategory.TOWER, new List<int>() { 6 }, 8, new CardEffects.Establishments.Basic.Major.CardEffectStadium());

                establishments.Push(stadium);
                establishments.Push(tvStation);
                establishments.Push(businessCenter);
            }

            var cardDeck = new CardDeck(establishments, revealedCards);

            CardDecks.Add(cardDeck);
        }

        public List<CardDeck> BuildCardDecksBasicGame(int revealedLowCards = 4, int revealedHighCards = 4, int revealedMajorCards = 2)
        {
            BuildCardDeckLowBasicGame(revealedLowCards);
            BuildCardDeckHighBasicGame(revealedHighCards);
            BuildCardDeckMajorBasicGame(revealedMajorCards);

            return CardDecks;
        }
    }
}
