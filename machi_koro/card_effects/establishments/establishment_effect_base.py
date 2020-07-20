from abc import ABC, abstractmethod


class CardEffect(ABC):
    @abstractmethod
    def activation(self, player):
        pass
