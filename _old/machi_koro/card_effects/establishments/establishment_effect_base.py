from abc import ABC, abstractmethod


class CardEffect(ABC):
    @abstractmethod
    def activate(self, player):
        pass
