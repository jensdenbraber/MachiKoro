from abc import ABC, abstractmethod


class LandmarkEffectBase(ABC):
    @abstractmethod
    def effect(self):
        pass
