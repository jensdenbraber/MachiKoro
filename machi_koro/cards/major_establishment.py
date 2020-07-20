import machi_koro.cards.establishment_base as establishment_base
import machi_koro.card_effects.establishments.secondary as card_effect_secondary
import machi_koro.utils as utils


class MajorEstablishment(establishment_base.EstablishmentBase):
    def __init__(self, name, construction_cost, activation_number, card_effect: card_effect_secondary.CardEffectSeconday):
        establishment_base.EstablishmentBase.__init__(
            self, name, construction_cost, activation_number, card_effect)

        self.set_card_type()
        self.set_card_color()
        self.set_card_icon()

    def set_card_type(self):
        self.card_type = utils.CardType.MajorEstablishment

    def set_card_color(self):
        self.card_color = utils.Color.PURPLE

    def set_card_icon(self):
        self.card_icon = utils.CardIcon.TOWER
