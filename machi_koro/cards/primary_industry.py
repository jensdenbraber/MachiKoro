from dataclasses import dataclass

import machi_koro.cards.establishment_base as establishment_base
import machi_koro.utils as utils

import machi_koro.card_effects.establishments.primary as card_effect_primary


@dataclass
class PrimaryIndustryCard(establishment_base.EstablishmentBase):
    card_type: utils.CardType = utils.CardType.PrimaryIndustry
    card_color: utils.CardColor = utils.CardColor.BLUE
    card_effect: card_effect_primary = card_effect_primary.CardEffectPrimary
