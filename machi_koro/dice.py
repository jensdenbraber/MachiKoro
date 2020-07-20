import random


class Dice():
    def __init__(self):
        self.value = -1

    def roll_dice(self):
        self.value = random.randint(1, 6)
        return self.value
