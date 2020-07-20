import machi_koro.cards.base_card as base_card
import machi_koro.card_effects.establishments.establishment_effect_base as establishment_effect_base


class EstablishmentBase(base_card.BaseCard):
    def __init__(self, name, construction_cost, activation_number, card_effect: establishment_effect_base.CardEffect) -> None:
        base_card.BaseCard.__init__(self, name)

        self.construction_cost = construction_cost
        self.activation_number = activation_number
        self.__establishment_effect = card_effect
        self.card_type = None
        self.card_color = None
        self.card_icon = None

    def set_card_type(self, card_type):
        self.card_type = card_type

    def set_card_color(self, color):
        self.card_color = color

    def set_card_icon(self, card_icon):
        self.card_icon = card_icon

    @property
    def card_effect(self):
        return self.__establishment_effect

    @card_effect.setter
    def card_effect(self, card_effect: establishment_effect_base.CardEffect):
        self.__establishment_effect = card_effect

    def activation(self):
        self.__establishment_effect.activation()

    # def set_game_typen(self, GameType):
    #     self.game_type = GameType

        # self.set_card_type()
        # self.set_card_color()
        # self.set_card_icon()

    # def set_card_type(self):
    #     self.card_type = CardType.LandMark

    # def set_card_color(self):
    #     self.card_color = Color.YELLOW

    # def set_card_icon(self):
    #     self.card_icon = CardIcon.TOWER
