from abc import ABC, abstractmethod


class LandmarkEffectBase(ABC):
    """Landmark bass class

    Args:
        ABC ([type]): [description]
    """
    @abstractmethod
    def effect(self):
        pass
