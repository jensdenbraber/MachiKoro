import machi_koro.card_deck as card_deck
import machi_koro.utils as utils
import machi_koro.cards.primary_industry as primary_industry
import machi_koro.cards.secondary_industry as secondary_industry
import machi_koro.cards.restaurants as restaurants
import machi_koro.cards.major_establishment as major_establishment

import machi_koro.card_effects.establishments.primary as card_effect_primary
import machi_koro.card_effects.establishments.secondary as card_effect_secondary
import machi_koro.card_effects.establishments.restaurants as card_effect_restaurants
import machi_koro.card_effects.establishments.major.business_center as card_effect_business_center
import machi_koro.card_effects.establishments.major.stadium as card_effect_stadium
import machi_koro.card_effects.establishments.major.tv_station as card_effect_tv_station


class CardDeckCreator():

    def create_low(self, max_number_revealed):
        establishment_cards = []

        for _ in range(6):
            # BLUE
            establishment_cards.append(primary_industry.PrimaryIndustryCard(
                "Wheat Field", 1, 1, utils.CardIcon.WHEAT, card_effect_primary.CardEffectPrimary(1)))
            establishment_cards.append(
                primary_industry.PrimaryIndustryCard("Ranch", 1, 2, utils.CardIcon.COW, card_effect_primary.CardEffectPrimary(1)))
            establishment_cards.append(
                primary_industry.PrimaryIndustryCard("Forest", 3, 5, utils.CardIcon.GEAR, card_effect_primary.CardEffectPrimary(1)))
            # GREEN
            establishment_cards.append(secondary_industry.SecondaryIndustryCard(
                "Bakery", 1, [2, 3], utils.CardIcon.BREAD, card_effect_secondary.CardEffectSeconday(1)))
            establishment_cards.append(secondary_industry.SecondaryIndustryCard(
                "Convenience Store", 2, 4, utils.CardIcon.BREAD, card_effect_secondary.CardEffectSeconday(3)))
            # RED
            establishment_cards.append(restaurants.RestaurantsCard(
                "Cafe", 2, 3, card_effect_restaurants.CardEffectRestaurants(1)))

        return card_deck.CardDeck(establishment_cards, max_number_revealed)

    def create_high(self, max_number_revealed):
        establishment_cards = []

        for _ in range(6):
            # BLUE
            establishment_cards.append(
                primary_industry.PrimaryIndustryCard("Mine", 6, 9, utils.CardIcon.GEAR, card_effect_primary.CardEffectPrimary(5)))
            establishment_cards.append(primary_industry.PrimaryIndustryCard(
                "Apple Orchard", 3, 10, utils.CardIcon.WHEAT, card_effect_primary.CardEffectPrimary(3)))
            # GREEN
            establishment_cards.append(secondary_industry.SecondaryIndustryCard(
                "Cheese Factory", 5, 7, utils.CardIcon.FACTORY, card_effect_secondary.CardEffectSeconday(3, utils.CardIcon.COW)))
            establishment_cards.append(secondary_industry.SecondaryIndustryCard(
                "Furniture Factory", 3, 8, utils.CardIcon.FACTORY, card_effect_secondary.CardEffectSeconday(3, utils.CardIcon.GEAR)))
            establishment_cards.append(secondary_industry.SecondaryIndustryCard(
                "Fruit and Vegetable Market", 2, [11, 12], utils.CardIcon.FRUIT, card_effect_secondary.CardEffectSeconday(3, utils.CardIcon.WHEAT)))
            # RED
            establishment_cards.append(
                restaurants.RestaurantsCard("Family Restaurant", 3, [9, 10], card_effect_restaurants.CardEffectRestaurants(2)))

        return card_deck.CardDeck(establishment_cards, max_number_revealed)

    def create_major(self, max_number_revealed):
        establishment_cards = []

        for _ in range(4):
            establishment_cards.append(major_establishment.MajorEstablishment(
                "Stadium", 6, 6, card_effect_stadium.CardEffectStadium()))
            establishment_cards.append(major_establishment.MajorEstablishment(
                "TV Station", 7, 6, card_effect_tv_station.CardEffectTvStation()))
            establishment_cards.append(
                major_establishment.MajorEstablishment("Business Center", 8, 6, card_effect_business_center.CardEffectBusinessCenter()))

        return card_deck.CardDeck(establishment_cards, max_number_revealed)
