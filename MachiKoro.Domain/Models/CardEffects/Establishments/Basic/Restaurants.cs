//#from .establishment_effect_base import CardEffect

//#class CardEffectRestaurants(CardEffect):
//#    def __init__(self, gold_amount: int):
//#        super().__init__()

//#        self.gold_amount = gold_amount

//#    def activate(self, player, active_player):
//#        bonus = 0
//#        if player.landmark_card['Shopping Mall'].is_constructed:
//#            bonus = 1

//#        if active_player.gold_amount < (self.gold_amount + bonus):
//#            player.gold_amount = player.gold_amount + active_player.gold_amount
//#            active_player.gold_amount = 0
//#        else:
//#            active_player.gold_amount = active_player.gold_amount - self.gold_amount - bonus
//#            player.gold_amount = player.gold_amount + self.gold_amount + bonus

//#        # if restaurant.name == "Family Restaurant":
//#        #     if active_player.gold_amount < (2 + bonus):
//#        #         player.gold_amount = player.gold_amount + active_player.gold_amount
//#        #         active_player.gold_amount = 0
//#        #     else:
//#        #         active_player.gold_amount = active_player.gold_amount - 2 - bonus
//#        #         player.gold_amount = player.gold_amount + 2 + bonus

namespace MachiKoro.Domain.Models.CardEffects.Establishments.Basic
{
    public class RestaurantsCardEffect : IEstablishmentEffect
    {
        public readonly int GoldReward;

        public RestaurantsCardEffect(int goldReward)
        {
            GoldReward = goldReward;
        }

        public void Activate()
        {
            //game.ActivePlayer.IsConstructLandmark()

            //foreach (var opponent in game.Opponents())
            //{
            //    if (game.ActivePlayer.GoldAmount == 0)
            //    {
            //        break;
            //    }

            //    game.ActivePlayer.GoldAmount--;
            //    opponent.GoldAmount++;
            //}
        }
    }
}