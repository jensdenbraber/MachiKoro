from dataclasses import dataclass

from .establishment_base import EstablishmentBase
from machi_koro.utils import CardColor, CardType
from machi_koro.card_deck import CardDeck
from machi_koro.card_effects.establishments.primary import CardEffectPrimary


@dataclass
class PrimaryIndustryCard(EstablishmentBase):
    card_type: CardType = CardType.PrimaryIndustry
    card_color: CardColor = CardColor.BLUE
    card_effect: CardEffectPrimary = CardEffectPrimary
    deck: CardDeck = CardDeck
