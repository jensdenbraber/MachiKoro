import random


class DiceRoll():
    def __init__(self, dices: list(Dice)):
        self.values = [len(dices)]
        for dice_index in range(0, len(dices)):
            self.values[dice_index] = dices[dice_index].roll_dice()

    def total(self):
        return sum(self.values)

    def is_same(self):
        if(len(self.values) < 2):
            return False
        return all(value == self.values[0] for value in self.values)


class Dice():
    def __init__(self, sides=6):
        self.sides = sides

    def roll_dice(self):
        return random.randint(1, self.sides)
