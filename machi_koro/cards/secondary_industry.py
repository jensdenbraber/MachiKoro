import machi_koro.cards.establishment_base as establishment_base
import machi_koro.utils as utils
import machi_koro.card_effects.establishments.secondary as card_effect_secondary


class SecondaryIndustryCard(establishment_base.EstablishmentBase):
    def __init__(self, name, construction_cost, activation_number, card_icon: utils.CardIcon, card_effect: card_effect_secondary.CardEffectSeconday):
        establishment_base.EstablishmentBase.__init__(
            self, name, construction_cost, activation_number, card_effect)

        self.card_type = utils.CardType.SecondaryIndustry
        self.card_color = utils.Color.GREEN
        self.set_card_icon(card_icon)

    def set_card_icon(self, card_icon):
        self.card_icon = card_icon
