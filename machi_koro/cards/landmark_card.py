import machi_koro.utils as Utils
import machi_koro.cards.base_card as base_card
import machi_koro.card_effects.landmarks.landmark_effect_base as landmark_effect_base


class LandmarkCard(base_card.BaseCard):
    def __init__(self, name, effect: landmark_effect_base.LandmarkEffectBase, completion_cost: int, is_constructed: bool):
        base_card.BaseCard.__init__(self, name)

        self.completion_cost = completion_cost
        self.is_constructed = is_constructed
        self.effect = effect

        self.set_card_type(Utils.CardType.LandMark)
        self.set_card_color(Utils.Color.YELLOW)
        self.set_card_icon(Utils.CardIcon.TOWER)

    def set_card_type(self, card_type):
        self.card_type = card_type

    def set_card_color(self, color):
        self.card_type = color

    def set_card_icon(self, card_icon):
        self.card_type = card_icon

    def enabled_effect(self):
        pass
