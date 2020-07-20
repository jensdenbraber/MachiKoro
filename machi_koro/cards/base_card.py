from abc import ABC, abstractmethod


class BaseCard(ABC):
    """ The base class for a simple card

    Args:
        ABC ([type]): [description]
    """
    def __init__(self, name):
        self.name = name
    
    @abstractmethod
    def set_card_type(self, card_type):
        self.card_type = card_type

    @abstractmethod
    def set_card_color(self, color):
        self.card_type = color

    @abstractmethod
    def set_card_icon(self, card_icon):
        self.card_type = card_icon

    # @abstractmethod
    # def set_game_typen(self, GameType):
    #     self.game_type = GameType
