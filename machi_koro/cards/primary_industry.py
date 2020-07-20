import machi_koro.cards.establishment_base as establishment_base
from machi_koro.utils import Color, CardIcon, CardType

import machi_koro.card_effects.establishments.primary as card_effect_primary


class PrimaryIndustryCard(establishment_base.EstablishmentBase):
    def __init__(self, name, construction_cost, activation_number, card_icon: CardIcon, card_effect: card_effect_primary.CardEffectPrimary):
        establishment_base.EstablishmentBase.__init__(
            self, name, construction_cost, activation_number, card_effect)

        self.card_type = CardType.PrimaryIndustry
        self.card_color = Color.BLUE
        self.set_card_icon(card_icon)

    def set_card_icon(self, card_icon):
        self.card_icon = card_icon
