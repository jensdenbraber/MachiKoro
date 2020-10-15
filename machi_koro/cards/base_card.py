from dataclasses import dataclass

import machi_koro.utils as utils


@dataclass
class BaseCard:
    name: str
    card_type: utils.CardType
    card_color: utils.CardColor
    card_icon: utils.CardIcon
