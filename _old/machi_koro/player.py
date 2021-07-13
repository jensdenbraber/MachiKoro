from .cards.establishment_base import EstablishmentBase
from .cards.primary_industry import PrimaryIndustryCard
from .cards.secondary_industry import SecondaryIndustryCard
from .cards.restaurants import RestaurantsCard
from .cards.landmark_card import LandmarkCard
from .player_choices import PlayerChoices
from .utils import PlayerType


class Player(object):
    def __init__(self, player_id: int, name: str, player_choices: PlayerChoices, player_type: PlayerType):
        self.__player_id = player_id
        self.__name = name
        self.gold_amount = None
        self.building_cards = list()
        self.landmark_cards = list()
        self.game = None
        player_choices.player = self
        self.player_choices = player_choices
        self.__player_type = player_type

    @property
    def player_id(self):
        """
        Id of the player

        Returns:
            int: Id of the player
        """
        return self.__player_id

    @property
    def name(self):
        """
        Name of the player

        Returns:
            str: Name of the player
        """
        return self.__name

    @property
    def player_type(self):
        """
        Type of the player, human or ai

        Returns:
            PlayerType: PlayerType
        """
        return self.__player_type

    def set_building_cards(self, building_cards: EstablishmentBase):
        self.building_cards = building_cards

    def set_landmark_cards(self, landmark_cards: LandmarkCard):
        self.landmark_cards = landmark_cards

    def is_constructed_landmark(self, landmark: LandmarkCard):
        return next(lm for lm in self.landmark_cards if lm.name == landmark.name).is_constructed

    def get_primary_cards(self):
        return list(filter(lambda card: isinstance(card, PrimaryIndustryCard), self.building_cards))

    def get_secondary_cards(self):
        return list(filter(lambda card: isinstance(card, SecondaryIndustryCard), self.building_cards))

    def get_restaurant_cards(self):
        return list(filter(lambda card: isinstance(card, RestaurantsCard), self.building_cards))

    def get_landmark_card(self, name: str):
        return next(landmark for landmark in self.landmark_cards if landmark.name == name)

    def can_throw_with_two_dices(self):
        return self.get_landmark_card("Train Station").is_constructed

    def choice_two_dices(self):
        return self.player_choices.choice_two_dices()

    def choice_build(self, buyable_establishments: EstablishmentBase, buyable_landmarks: LandmarkCard):
        return self.player_choices.choice_build(buyable_establishments, buyable_landmarks)

    def receive_establishment(self, card):
        self.building_cards.append(card)

        # - To begin their turn a player rolls the dice. At the start of the game each player will roll a single die.
        # - Once a player has built their Train Station, they may roll one or two dice on their turn.
        # - When rolling two dice, the dice are always summed together.
