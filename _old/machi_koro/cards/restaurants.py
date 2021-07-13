from dataclasses import dataclass
from machi_koro.card_deck import CardDeck
from .establishment_base import EstablishmentBase
from machi_koro.utils import CardColor, CardType, CardIcon
from machi_koro.card_effects.establishments.restaurants import CardEffectRestaurants


@dataclass
class RestaurantsCard(EstablishmentBase):
    card_type: CardType = CardType.Restaurants
    card_color: CardColor = CardColor.RED
    card_icon: CardIcon = CardIcon.CUP
    card_effect: CardEffectRestaurants = None
    deck: CardDeck = None
