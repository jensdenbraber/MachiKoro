import machi_koro.cards.establishment_base as establishment_base
import machi_koro.card_effects.establishments.secondary as card_effect_secondary
import machi_koro.utils as utils


from dataclasses import dataclass


@dataclass
class MajorEstablishment(establishment_base.EstablishmentBase):
    card_type: utils.CardType.MajorEstablishment
    card_color: utils.CardColor.PURPLE
    card_icon: utils.CardIcon.TOWER
    card_effect: card_effect_secondary.CardEffectSeconday
