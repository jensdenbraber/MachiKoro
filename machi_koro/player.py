import machi_koro.cards.establishment_base as establishment_base
import machi_koro.cards.primary_industry as primary_industry
import machi_koro.cards.secondary_industry as secondary_industry
import machi_koro.cards.restaurants as restaurants
import machi_koro.cards.landmark_card as landmark_card


class Player():
    def __init__(self, player_id, name):
        self.player_id = player_id
        self.name = name
        self.gold_amount = None
        self.building_cards = []
        self.landmark_cards = []

    def set_building_cards(self, building_cards: (establishment_base.EstablishmentBase)):
        self.building_cards = building_cards

    def set_landmark_cards(self, landmark_cards: (landmark_card.LandmarkCard)):
        self.landmark_cards = landmark_cards

    def is_constructed_landmark(self, landmark: landmark_card.LandmarkCard):
        return next(zxc for zxc in self.landmark_cards if zxc.name == landmark.name).is_constructed

    def get_primary_cards(self):
        return list(filter(lambda elm: isinstance(elm, primary_industry.PrimaryIndustryCard), self.building_cards))

    def get_secondary_cards(self):
        return list(filter(lambda elm: isinstance(elm, secondary_industry.SecondaryIndustryCard), self.building_cards))

    def get_restaurant_cards(self):
        return list(filter(lambda elm: isinstance(elm, restaurants.RestaurantsCard), self.building_cards))

    def roll_dice(self, dice):
        return dice.roll_dice()

        # - To begin their turn a player rolls the dice. At the start of the game each player will roll a single die.
        # - Once a player has built their Train Station, they may roll one or two dice on their turn.
        # - When rolling two dice, the dice are always summed together.

    def earn_income(self, dice_number):
        pass
        # 1) Restaurants (Red)
        # 2) Secondary Industry (Green)and Primary Industry (Blue)
        # 3) Major Establishments (Purple)

    def construct(self):
        pass

    # def buy_building(self):
    #     pass

    # def unlock_goal(self):
    #     pass
