from .card_deck import CardDeck
from .utils import CardIcon
from .cards.primary_industry import PrimaryIndustryCard
from .cards.secondary_industry import SecondaryIndustryCard
from .cards.restaurants import RestaurantsCard
from .cards.major_establishment import MajorEstablishment

from .card_effects.establishments.primary import CardEffectPrimary
from .card_effects.establishments.secondary import CardEffectSeconday
from .card_effects.establishments.restaurants import CardEffectRestaurants
from .card_effects.establishments.major.business_center import CardEffectBusinessCenter
from .card_effects.establishments.major.stadium import CardEffectStadium
from .card_effects.establishments.major.tv_station import CardEffectTvStation


class CardDeckCreator():

    def create_low(self, max_number_revealed=0):
        establishment_cards = []

        for _ in range(6):
            # BLUE
            establishment_cards.append(PrimaryIndustryCard(
                "Wheat Field", card_icon=CardIcon.WHEAT, construction_cost=1, activation_number=[1], card_effect=CardEffectPrimary(1), deck=None))
            establishment_cards.append(PrimaryIndustryCard(
                "Ranch", card_icon=CardIcon.COW, construction_cost=1, activation_number=[2], card_effect=CardEffectPrimary(1), deck=None))
            establishment_cards.append(PrimaryIndustryCard(
                "Forest", card_icon=CardIcon.GEAR, construction_cost=3, activation_number=[5], card_effect=CardEffectPrimary(1), deck=None))
            # GREEN
            establishment_cards.append(SecondaryIndustryCard(
                "Bakery", card_icon=CardIcon.BREAD, construction_cost=1, activation_number=[2, 3], card_effect=CardEffectSeconday(1), deck=None))
            establishment_cards.append(SecondaryIndustryCard(
                "Convenience Store", card_icon=CardIcon.BREAD, construction_cost=2, activation_number=[4], card_effect=CardEffectSeconday(3), deck=None))
            # RED
            establishment_cards.append(RestaurantsCard(
                "Cafe", construction_cost=2, activation_number=[3], card_effect=CardEffectRestaurants(1), deck=None))

        card_deck = CardDeck(establishment_cards, max_number_revealed)

        for card in card_deck.cards:
            card.deck = card_deck

        for card in card_deck.revealed_cards:
            card.deck = card_deck

        return card_deck

    def create_high(self, max_number_revealed=0):
        establishment_cards = []

        for _ in range(6):
            # BLUE
            establishment_cards.append(
                PrimaryIndustryCard("Mine", card_icon=CardIcon.GEAR, construction_cost=6, activation_number=9, card_effect=CardEffectPrimary(5), deck=None))
            establishment_cards.append(PrimaryIndustryCard(
                "Apple Orchard", card_icon=CardIcon.WHEAT, construction_cost=3, activation_number=10, card_effect=CardEffectPrimary(3), deck=None))
            # GREEN
            establishment_cards.append(SecondaryIndustryCard(
                "Cheese Factory", card_icon=CardIcon.FACTORY, construction_cost=5, activation_number=7, card_effect=CardEffectSeconday(3, CardIcon.COW), deck=None))
            establishment_cards.append(SecondaryIndustryCard(
                "Furniture Factory", card_icon=CardIcon.FACTORY, construction_cost=3, activation_number=8, card_effect=CardEffectSeconday(3, CardIcon.GEAR), deck=None))
            establishment_cards.append(SecondaryIndustryCard("Fruit and Vegetable Market", card_icon=CardIcon.FRUIT, construction_cost=2, activation_number=[
                                       11, 12], card_effect=CardEffectSeconday(3, CardIcon.WHEAT), deck=None))
            # RED
            establishment_cards.append(RestaurantsCard("Family Restaurant", construction_cost=3, activation_number=[
                                       9, 10], card_effect=CardEffectRestaurants(2), deck=None))

        card_deck = CardDeck(establishment_cards, max_number_revealed)

        for card in card_deck.cards:
            card.deck = card_deck

        for card in card_deck.revealed_cards:
            card.deck = card_deck

        return card_deck

    def create_major(self, max_number_revealed=0):
        establishment_cards = []

        for _ in range(4):
            establishment_cards.append(MajorEstablishment(
                "Stadium", construction_cost=6, activation_number=6, card_effect=CardEffectStadium(), deck=None))
            establishment_cards.append(MajorEstablishment(
                "TV Station", construction_cost=7, activation_number=6, card_effect=CardEffectTvStation(), deck=None))
            establishment_cards.append(MajorEstablishment(
                "Business Center", construction_cost=8, activation_number=6, card_effect=CardEffectBusinessCenter(), deck=None))

        card_deck = CardDeck(establishment_cards, max_number_revealed)

        for card in card_deck.cards:
            card.deck = card_deck

        for card in card_deck.revealed_cards:
            card.deck = card_deck

        return card_deck
