from dataclasses import dataclass
from machi_koro.card_deck import CardDeck
from .establishment_base import EstablishmentBase
from machi_koro.utils import CardColor, CardType
from machi_koro.card_effects.establishments.secondary import CardEffectSeconday


@dataclass
class SecondaryIndustryCard(EstablishmentBase):
    card_type: CardType = CardType.SecondaryIndustry
    card_color: CardColor = CardColor.GREEN
    card_effect: CardEffectSeconday = CardEffectSeconday
    deck: CardDeck = None
