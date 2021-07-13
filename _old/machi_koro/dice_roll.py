from typing import Iterable
from machi_koro.dice import Dice


class DiceRoll():
    def __init__(self, dices: Iterable[Dice]):
        self.values = [len(dices)]

        for dice_index in range(0, len(dices)):
            self.values[dice_index] = dices[dice_index].roll_dice()

    @property
    def total(self):
        return sum(self.values)

    def is_same(self):
        if len(self.values) < 2:
            return False
        return all(value == self.values[0] for value in self.values)
