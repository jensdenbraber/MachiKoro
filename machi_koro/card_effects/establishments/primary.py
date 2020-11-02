from .establishment_effect_base import CardEffect


class CardEffectPrimary(CardEffect):
    def __init__(self, gold_amount: int):
        super().__init__()
        self.gold_amount = gold_amount

    def activate(self, active_player):
        active_player.gold_amount = active_player.gold_amount + self.gold_amount
