from dataclasses import dataclass
from machi_koro.cards.base_card import BaseCard
from machi_koro.card_effects.landmarks.landmark_effect_base import LandmarkEffectBase
from machi_koro.utils import CardType, CardColor, CardIcon


@dataclass
class LandmarkCard(BaseCard):
    card_type: CardType = CardType.LandMark
    card_color: CardColor = CardColor.YELLOW
    card_icon: CardIcon = CardIcon.TOWER
    is_constructed: bool = False
    effect: LandmarkEffectBase = None
    completion_cost: int = None
