from abc import ABC, abstractmethod
from .cards.establishment_base import EstablishmentBase
from .cards.landmark_card import LandmarkCard


class PlayerChoices(ABC):
    def __init__(self):
        self.player = None

    @abstractmethod
    def choice_two_dices(self):
        raise NotImplementedError

    @abstractmethod
    def choice_build(self, buyable_establishments: EstablishmentBase, buyable_landmarks: LandmarkCard):
        raise NotImplementedError
