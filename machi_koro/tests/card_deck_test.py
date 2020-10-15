import pytest
from machi_koro.cards.primary_industry import PrimaryIndustryCard
from machi_koro.cards.secondary_industry import SecondaryIndustryCard
from machi_koro.cards.restaurants import RestaurantsCard
from machi_koro.cards.major_establishment import MajorEstablishment
import machi_koro.card_deck_factory as card_deck_factory


def test_category_cards_low():
    card_deck_creator = card_deck_factory.CardDeckCreator()
    cards = card_deck_creator.create_low().cards
    assert len(cards) == 36

    primary_industry_cards = list(
        filter(lambda x: isinstance(x, PrimaryIndustryCard), cards))
    secondary_industry_cards = list(
        filter(lambda x: isinstance(x, SecondaryIndustryCard), cards))
    restaurant_cards = list(
        filter(lambda x: isinstance(x, RestaurantsCard), cards))

    assert len(primary_industry_cards) == 18
    assert len(secondary_industry_cards) == 12
    assert len(restaurant_cards) == 6

    wheat_fields = list(
        filter(lambda x: x.name == "Wheat Field", primary_industry_cards))
    ranches = list(filter(lambda x: x.name == "Ranch", primary_industry_cards))
    forests = list(filter(lambda x: x.name ==
                          "Forest", primary_industry_cards))

    bakeries = list(filter(lambda x: x.name ==
                           "Bakery", secondary_industry_cards))
    convenience_store = list(
        filter(lambda x: x.name == "Convenience Store", secondary_industry_cards))

    cafes = list(filter(lambda x: x.name == "Cafe", restaurant_cards))

    assert len(wheat_fields) == 6
    assert len(ranches) == 6
    assert len(forests) == 6

    assert len(bakeries) == 6
    assert len(convenience_store) == 6

    assert len(cafes) == 6


def test_category_cards_high():
    card_deck_creator = card_deck_factory.CardDeckCreator()
    cards = card_deck_creator.create_high().cards
    assert len(cards) == 36

    primary_industry_cards = list(
        filter(lambda x: isinstance(x, PrimaryIndustryCard), cards))
    secondary_industry_cards = list(
        filter(lambda x: isinstance(x, SecondaryIndustryCard), cards))
    restaurant_cards = list(
        filter(lambda x: isinstance(x, RestaurantsCard), cards))

    assert len(primary_industry_cards) == 12
    assert len(secondary_industry_cards) == 18
    assert len(restaurant_cards) == 6

    mine = list(filter(lambda x: x.name == "Mine", primary_industry_cards))
    apple_orchard = list(filter(lambda x: x.name ==
                                "Apple Orchard", primary_industry_cards))

    cheese_factory = list(filter(lambda x: x.name ==
                                 "Cheese Factory", secondary_industry_cards))
    furniture_factory = list(filter(lambda x: x.name ==
                                    "Furniture Factory", secondary_industry_cards))
    fruit_and_vegetable_market = list(
        filter(lambda x: x.name == "Fruit and Vegetable Market", secondary_industry_cards))

    family_restaurants = list(filter(lambda x: x.name ==
                                     "Family Restaurant", restaurant_cards))

    assert len(mine) == 6
    assert len(apple_orchard) == 6

    assert len(cheese_factory) == 6
    assert len(furniture_factory) == 6
    assert len(fruit_and_vegetable_market) == 6

    assert len(family_restaurants) == 6


def test_category_cards_major():
    card_deck_creator = card_deck_factory.CardDeckCreator()
    cards = card_deck_creator.create_major().cards
    assert len(cards) == 12

    major_establishment_cards = list(
        filter(lambda x: isinstance(x, MajorEstablishment), cards))

    assert len(major_establishment_cards) == 12

    stadium = list(filter(lambda x: x.name == "Stadium",
                          major_establishment_cards))
    tv_Station = list(
        filter(lambda x: x.name == "TV Station", major_establishment_cards))
    business_center = list(
        filter(lambda x: x.name == "Business Center", major_establishment_cards))

    assert len(stadium) == 4
    assert len(tv_Station) == 4
    assert len(business_center) == 4


@ pytest.mark.parametrize('revealed_amount', [*range(0, 37)])
def test_revealed_deck_low(revealed_amount):
    card_deck_creator = card_deck_factory.CardDeckCreator()
    card_deck = card_deck_creator.create_low(revealed_amount)
    assert len(card_deck.revealed_cards) == revealed_amount


@ pytest.mark.parametrize('revealed_amount', [*range(0, 37)])
def test_revealed_deck_high(revealed_amount):
    card_deck_creator = card_deck_factory.CardDeckCreator()
    card_deck = card_deck_creator.create_high(revealed_amount)
    assert len(card_deck.revealed_cards) == revealed_amount


@ pytest.mark.parametrize('revealed_amount', [*range(0, 13)])
def test_revealed_deck_major(revealed_amount):
    card_deck_creator = card_deck_factory.CardDeckCreator()
    card_deck = card_deck_creator.create_major(revealed_amount)
    assert len(card_deck.revealed_cards) == revealed_amount

    card_count = len(card_deck.cards)
    if len(card_deck.revealed_cards) != 0:
        card_deck.remove_card(card_deck.revealed_cards[0])
    card_deck.reveal_top_card()

    assert len(card_deck.cards) == card_count - 1
