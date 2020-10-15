import machi_koro.card_effects.establishments.establishment_effect_base as establishment_effect_base
import machi_koro.player as Player


class CardEffectMajor(establishment_effect_base.CardEffect):
    def activate(self, active_player: Player.Player):
        active_player.gold_amount = active_player.gold_amount + 1
