from machi_koro.lobby import Lobby
from machi_koro.player import Player
from machi_koro.player_choices import PlayerChoices

if __name__ == "__main__":
    lobby = Lobby().getInstance()

    players = [Player(1, "player 1", PlayerChoices()),
               Player(2, "player 2", PlayerChoices())]

    lobby.setup_new_game(players)
