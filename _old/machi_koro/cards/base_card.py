from dataclasses import dataclass
from machi_koro.utils import CardColor, CardIcon, CardType


@dataclass
class BaseCard:
    name: str
    card_type: CardType
    card_color: CardColor
    card_icon: CardIcon
