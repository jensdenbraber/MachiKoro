import machi_koro.lobby as lobby
import machi_koro.player as player

if __name__ == "__main__":
    lobby = lobby.Lobby().getInstance()

    players = [player.Player(1, "player 1"), player.Player(2, "player 2")]

    lobby.setup_new_game(players)
