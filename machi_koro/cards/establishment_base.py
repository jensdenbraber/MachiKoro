from dataclasses import dataclass
from machi_koro.card_deck import CardDeck
from machi_koro.cards.base_card import BaseCard
from machi_koro.card_effects.establishments.establishment_effect_base import CardEffect
from machi_koro.utils import CardIcon


@dataclass
class EstablishmentBase(BaseCard):
    card_icon: CardIcon = CardIcon.UNKNOWN
    construction_cost: int = None
    activation_number: list() = None
    card_effect: CardEffect = None
    deck: CardDeck = None
