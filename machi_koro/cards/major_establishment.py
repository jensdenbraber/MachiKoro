from dataclasses import dataclass
from machi_koro.card_deck import CardDeck
from .establishment_base import EstablishmentBase
from machi_koro.card_effects.establishments.secondary import CardEffectSeconday
from machi_koro.utils import CardColor, CardIcon, CardType


@dataclass
class MajorEstablishment(EstablishmentBase):
    card_type: CardType = CardType.MajorEstablishment
    card_color: CardColor = CardColor.PURPLE
    card_icon: CardIcon = CardIcon.TOWER
    card_effect: CardEffectSeconday = None
    deck: CardDeck = CardDeck
