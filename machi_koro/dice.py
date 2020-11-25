import random


class Dice():
    def __init__(self, sides=6, seed=None):
        self.__sides = sides
        self.__seed = seed
        self.__last_value = None

    def roll_dice(self):
        random.seed(self.__seed)
        self.__last_value = random.randint(1, self.__sides)
        return self.__last_value

    def last_throw(self):
        return self.__last_value
