import pytest
from machi_koro.utils import GameType
from machi_koro.game import Game
from machi_koro.player import Player
from machi_koro.player_choices import PlayerChoices


@pytest.mark.parametrize('players', [[Player(0, "player 1", PlayerChoices), Player(1, "player 2", PlayerChoices)],
                                     [Player(0, "player 1", PlayerChoices), Player(
                                         1, "player 2", PlayerChoices), Player(2, "player 3", PlayerChoices)],
                                     [Player(0, "player 1", PlayerChoices), Player(1, "player 2", PlayerChoices), Player(2, "player 3", PlayerChoices), Player(3, "player 4", PlayerChoices)]])
def test_machi_koro_game_setup(players):
    """
    docstring
    """

    game1 = Game(0, players)
    assert game1.active_player.player_id == 0
    assert game1.active_player.name == "player 1"
    assert game1.game_id == 0
    assert game1.game_type == GameType.BASEGAME
    assert game1.number_of_orbits == 1
    assert game1.number_of_turns == 1
    assert game1.players[0].name == "player 1"
    assert game1.players[0].gold_amount == 3
    assert len(game1.players[0].building_cards) == 2
    assert len(game1.players[0].landmark_cards) == 4

    assert game1.players[1].name == "player 2"
    assert game1.players[1].gold_amount == 3
    assert len(game1.players[1].building_cards) == 2
    assert len(game1.players[1].landmark_cards) == 4

    if len(players) == 3:
        assert game1.players[2].name == "player 3"
        assert game1.players[2].gold_amount == 3
        assert len(game1.players[2].building_cards) == 2
        assert len(game1.players[2].landmark_cards) == 4

    if len(players) == 4:
        assert game1.players[3].name == "player 4"
        assert game1.players[3].gold_amount == 3
        assert len(game1.players[3].building_cards) == 2
        assert len(game1.players[3].landmark_cards) == 4


@pytest.mark.parametrize('players', [[Player(0, "player 1", PlayerChoices), Player(1, "player 2", PlayerChoices)],
                                     [Player(0, "player 1", PlayerChoices), Player(
                                         1, "player 2", PlayerChoices), Player(2, "player 3", PlayerChoices)],
                                     [Player(0, "player 1", PlayerChoices), Player(1, "player 2", PlayerChoices), Player(2, "player 3", PlayerChoices), Player(3, "player 4", PlayerChoices)]])
@pytest.mark.parametrize('dice', [*range(1, 13)])
def test_machi_koro_game_first_turn(players, dice):
    """
    docstring
    """

    game1 = Game(0, players)
    assert game1.active_player.player_id == 0
    assert game1.active_player.name == "player 1"

    game1.play_turn(dice)
    assert game1.active_player.player_id == 1
    assert game1.active_player.name == "player 2"

    if len(players) == 3:
        game1.play_turn(dice)
        assert game1.active_player.player_id == 2
        assert game1.active_player.name == "player 3"

    if len(players) == 4:
        game1.play_turn(dice)
        assert game1.active_player.player_id == 2
        assert game1.active_player.name == "player 3"
        game1.play_turn(dice)
        assert game1.active_player.player_id == 3
        assert game1.active_player.name == "player 4"
