from .cards.establishment_base import EstablishmentBase
from .cards.primary_industry import PrimaryIndustryCard
from .cards.secondary_industry import SecondaryIndustryCard
from .cards.restaurants import RestaurantsCard
from .cards.landmark_card import LandmarkCard
from .player_choices import PlayerChoices


class Player():
    def __init__(self, player_id: int, name: str, player_choices: PlayerChoices):
        self.player_id = player_id
        self.name = name
        self.gold_amount = None
        self.building_cards = list()
        self.landmark_cards = list()
        self.game = None
        player_choices.player = self
        self.player_choices = player_choices

    def set_building_cards(self, building_cards: (EstablishmentBase)):
        self.building_cards = building_cards

    def set_landmark_cards(self, landmark_cards: (LandmarkCard)):
        self.landmark_cards = landmark_cards

    def is_constructed_landmark(self, landmark: LandmarkCard):
        return next(lm for lm in self.landmark_cards if lm.name == landmark.name).is_constructed

    def get_primary_cards(self):
        return list(filter(lambda card: isinstance(card, PrimaryIndustryCard), self.building_cards))

    def get_secondary_cards(self):
        return list(filter(lambda card: isinstance(card, SecondaryIndustryCard), self.building_cards))

    def get_restaurant_cards(self):
        return list(filter(lambda card: isinstance(card, RestaurantsCard), self.building_cards))

    def get_landmark_card(self, name):
        return next(landmark for landmark in self.landmark_cards if landmark.name == name)

    def can_throw_with_two_dices(self):
        return self.get_landmark_card("Train Station").is_constructed

    def choice_two_dices(self):
        return self.player_choices.choice_two_dices()

    def choice_build(self, buyable_establishment: EstablishmentBase, buyable_landmarks: LandmarkCard):
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
