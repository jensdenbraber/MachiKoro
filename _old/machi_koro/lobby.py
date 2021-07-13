from machi_koro.game import Game
from machi_koro.player import Player


class Lobby():
    __instance = None

    @staticmethod
    def getInstance():
        """ Static access method. """
        if Lobby.__instance == None:
            Lobby()
        return Lobby.__instance

    def __init__(self):
        """ Virtually private constructor. """
        if Lobby.__instance != None:
            raise Exception("This class is a singleton!")
        else:
            Lobby.__instance = self

    def setup_new_game(self, players: list(Player), deck_cards_low_revealed=4, deck_cards_high_revealed=4, deck_cards_major_revealed=2):
        game_id = 0
        Game(game_id, players, deck_cards_low_revealed,
             deck_cards_high_revealed, deck_cards_major_revealed).start()
