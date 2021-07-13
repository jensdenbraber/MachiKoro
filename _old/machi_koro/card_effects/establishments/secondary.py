from .establishment_effect_base import CardEffect
from machi_koro.utils import CardIcon


class CardEffectSeconday(CardEffect):
    def __init__(self, gold_amount: int, card_icon: CardIcon = None):
        super().__init__()
        self.gold_amount = gold_amount
        self.card_icon = card_icon

    def activate(self, active_player):
        if self.card_icon is not None:
            for secondary_card in active_player.get_secondary_cards():
                if secondary_card.card_icon == self.card_icon:
                    active_player.gold_amount = active_player.gold_amount + self.gold_amount
        else:
            active_player.gold_amount = active_player.gold_amount + self.gold_amount
