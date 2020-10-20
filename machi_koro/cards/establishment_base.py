from dataclasses import dataclass
import machi_koro.cards.base_card as base_card
import machi_koro.card_effects.establishments.establishment_effect_base as establishment_effect_base
import machi_koro.utils as utils




@dataclass
class EstablishmentBase(base_card.BaseCard):
    card_icon: utils.CardIcon = utils.CardIcon.UNKNOWN
    construction_cost: int = None
    activation_number: [int] = None
    card_effect: establishment_effect_base.CardEffect = None
