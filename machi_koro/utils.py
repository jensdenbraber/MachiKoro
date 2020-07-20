from enum import Enum


class CardIcon(Enum):
    WHEAT = 1
    BREAD = 2
    COW = 3
    CUP = 4
    GEAR = 5
    FRUIT = 6
    TOWER = 7
    FACTORY = 8


class Color(Enum):
    BLUE = 1
    GREEN = 2
    RED = 3
    PURPLE = 4
    YELLOW = 5


class CardType(Enum):
    PrimaryIndustry = 1
    SecondaryIndustry = 2
    Restaurants = 3
    MajorEstablishment = 4
    LandMark = 5


class GameType(Enum):
    BASEGAME = 1
    HARBOR_EXPANSION = 2
