import machi_koro.cards.establishment_base as establishment_base
import machi_koro.utils as utils
import machi_koro.card_effects.establishments.secondary as card_effect_secondary

from dataclasses import dataclass


@dataclass
class SecondaryIndustryCard(establishment_base.EstablishmentBase):
    card_type: utils.CardType = utils.CardType.SecondaryIndustry
    card_color: utils.CardColor = utils.CardColor.GREEN
    card_effect: card_effect_secondary = card_effect_secondary.CardEffectSeconday
