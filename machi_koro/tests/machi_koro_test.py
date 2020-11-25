import pytest

from machi_koro.dice import Dice
from machi_koro.cards import landmark_card
from machi_koro.cards.establishment_base import EstablishmentBase

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


class PlayerChoiceTest(PlayerChoices):
    def choice_two_dices(self):
        return False

    def choice_build(self, buyable_establishments: EstablishmentBase, buyable_landmarks: landmark_card):
        return buyable_establishments[0]


@pytest.mark.parametrize('players', [[Player(0, "player 1", PlayerChoiceTest()), Player(1, "player 2", PlayerChoiceTest())],
                                     [Player(0, "player 1", PlayerChoiceTest()), Player(
                                         1, "player 2", PlayerChoiceTest()), Player(2, "player 3", PlayerChoiceTest())],
                                     [Player(0, "player 1", PlayerChoiceTest()), Player(1, "player 2", PlayerChoiceTest()), Player(2, "player 3", PlayerChoiceTest()), Player(3, "player 4", PlayerChoiceTest())]])
@pytest.mark.parametrize('dice_seed', [1, 3, 9, 5, 6, 2])
# @pytest.mark.parametrize('dice', [*range(1, 13)])
# @pytest.mark.skip(reason="no way of currently testing this")
def test_machi_koro_game_first_turn(players, dice_seed):
    """
    docstring
    """

    game1 = Game(0, players)
    assert game1.active_player.player_id == 0
    assert game1.active_player.name == "player 1"

    dice1 = Dice(seed=dice_seed)
    dice2 = Dice(seed=dice_seed)

    print("dice1: " + str(dice1.roll_dice()))
    print("dice2: " + str(dice2.roll_dice()))

    game1.play_turn(dice1, dice2)
    assert game1.active_player.player_id == 1
    assert game1.active_player.name == "player 2"

    if len(players) == 3:
        game1.play_turn(dice1, dice2)
        assert game1.active_player.player_id == 2
        assert game1.active_player.name == "player 3"

    if len(players) == 4:
        game1.play_turn(dice1, dice2)
        assert game1.active_player.player_id == 2
        assert game1.active_player.name == "player 3"
        game1.play_turn(dice1, dice2)
        assert game1.active_player.player_id == 3
        assert game1.active_player.name == "player 4"
