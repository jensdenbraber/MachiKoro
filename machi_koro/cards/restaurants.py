import machi_koro.cards.establishment_base as establishment_base
import machi_koro.utils as Utils
import machi_koro.card_effects.establishments.restaurants as card_effect_restaurants


class RestaurantsCard(establishment_base.EstablishmentBase):
    def __init__(self, name, construction_cost, activation_number, card_effect: card_effect_restaurants.CardEffectRestaurants):
        establishment_base.EstablishmentBase.__init__(
            self, name, construction_cost, activation_number, card_effect)

        self.card_type = Utils.CardType.Restaurants
        self.card_color = Utils.Color.RED
        self.card_icon = Utils.CardIcon.CUP

    # def activation(self, player, active_player):

    #     bonus = 0
    #     if player.landmark_card['Shopping Mall'].is_constrcuted:
    #         bonus = 1

    #     if self.name == "Cafe":
    #         if active_player.gold_amount < (1 + bonus):
    #             active_player.gold_amount = 0
    #             player.gold_amount = player.gold_amount + active_player.gold_amount
    #         else:
    #             active_player.gold_amount = active_player.gold_amount - 1 - bonus
    #             player.gold_amount = player.gold_amount + 1 + bonus

    #     if self.name == "Family Restaurant":
    #         if active_player.gold_amount < (2 + bonus):
    #             active_player.gold_amount = 0
    #             player.gold_amount = player.gold_amount + active_player.gold_amount
    #         else:
    #             active_player.gold_amount = active_player.gold_amount - 2 - bonus
    #             player.gold_amount = player.gold_amount + 2 + bonus
