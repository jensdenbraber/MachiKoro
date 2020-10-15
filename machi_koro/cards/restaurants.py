import machi_koro.cards.establishment_base as establishment_base
import machi_koro.utils as utils
import machi_koro.card_effects.establishments.restaurants as card_effect_restaurants

from dataclasses import dataclass


@dataclass
class RestaurantsCard(establishment_base.EstablishmentBase):
    card_type: utils.CardType = utils.CardType.Restaurants
    card_color: utils.CardColor = utils.CardColor.RED
    card_icon: utils.CardIcon = utils.CardIcon.CUP
    card_effect: card_effect_restaurants = card_effect_restaurants.CardEffectRestaurants
