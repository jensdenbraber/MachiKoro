from dataclasses import dataclass
import machi_koro.cards.base_card as base_card
import machi_koro.card_effects.landmarks.landmark_effect_base as landmark_effect_base

import machi_koro.utils as utils


@dataclass
class LandmarkCard(base_card.BaseCard):
    card_type: utils.CardType = utils.CardType.LandMark
    card_color: utils.CardColor = utils.CardColor.YELLOW
    card_icon: utils.CardIcon = utils.CardIcon.TOWER
    is_constructed: bool = False
    effect: landmark_effect_base.LandmarkEffectBase = None
    completion_cost: int = None
