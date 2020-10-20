import machi_koro.cards.establishment_base as establishment_base
import machi_koro.cards.primary_industry as primary_industry
import machi_koro.cards.secondary_industry as secondary_industry
import machi_koro.cards.restaurants as restaurants
import machi_koro.cards.landmark_card as landmark_card
import machi_koro.player_choices as player_choices


class Player():
    def __init__(self, player_id: int, name: str, player_choices: player_choices.PlayerChoices):
        self.player_id = player_id
        self.name = name
        self.gold_amount = None
        self.building_cards = list()
        self.landmark_cards = list()
        self.game = None
        player_choices.player = self
        self.player_choices = player_choices

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

    def get_landmark_card(self, name):
        return next(landmark for landmark in self.landmark_cards if landmark.name == name)

        # for landmark in self.landmark_cards:
        #     if landmark.name == name:
        #         return landmark
        # return None

    def can_throw_with_two_dices(self):
        return self.get_landmark_card("Train Station").is_constructed

    def choice_two_dices(self):
        return self.player_choices.choice_two_dices()

    def choice_build(self, buyable_establishment: establishment_base, buyable_landmarks: landmark_card.LandmarkCard):
        return self.player_choices.choice_build(buyable_establishment, buyable_landmarks)

    def receive_establishment(self, card):
        self.building_cards.append(card)
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
