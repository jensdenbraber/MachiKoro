import random


class Dice():
    @staticmethod
    def roll_dice():
        return [random.randint(1, 6), 0]

    @staticmethod
    def roll_2_dice():
        return [random.randint(1, 6), random.randint(1, 6)]
