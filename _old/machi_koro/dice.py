import random


class Dice():
    def __init__(self, sides=6, seed=None):
        self.__sides = sides
        self.__seed = seed
        self.__last_value = None

    @property
    def sides(self):
        """
        Number of sides of the dice

        Returns:
            int: number of sides of the dice
        """
        return self.__sides

    @property
    def seed(self):
        """
        Gives the seed number that is used for the dice

        Returns:
            int: seed number
        """
        return self.__seed

    @property
    def last_throw(self):
        """
        Last thrown number

        Returns:
            int: last thrown number
        """
        return self.__last_value

    def roll_dice(self):
        random.seed(self.__seed)
        self.__last_value = random.randint(1, self.__sides)
        return self.__last_value
