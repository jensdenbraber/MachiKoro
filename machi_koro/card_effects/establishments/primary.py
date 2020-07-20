import machi_koro.card_effects.establishments.establishment_effect_base as establishment_effect_base


class CardEffectPrimary(establishment_effect_base.CardEffect):
    def __init__(self, gold_amount: int):
        super().__init__()
        self.gold_amount = gold_amount

    def activation(self, active_player):
        active_player.gold_amount = active_player.gold_amount + self.gold_amount
