from machi_koro.card_effects.establishments.establishment_effect_base import CardEffect
from machi_koro.player import Player


class CardEffectMajor(CardEffect):
    def activate(self, active_player: Player):
        active_player.gold_amount = active_player.gold_amount + 1
