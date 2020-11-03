from typing import Iterable
from collections import deque
from machi_koro.dice import Dice
from machi_koro.dice_roll import DiceRoll
from machi_koro.player import Player

from machi_koro.utils import CardColor, CardIcon, GameType
from machi_koro.card_deck_factory import CardDeckCreator

from machi_koro.cards.landmark_card import LandmarkCard
from machi_koro.cards.primary_industry import PrimaryIndustryCard
from machi_koro.cards.secondary_industry import SecondaryIndustryCard
from machi_koro.cards.major_establishment import MajorEstablishment
from machi_koro.cards.establishment_base import EstablishmentBase


from machi_koro.card_effects.establishments.primary import CardEffectPrimary
from machi_koro.card_effects.establishments.secondary import CardEffectSeconday
from machi_koro.card_effects.landmarks.train_station import TrainStation
from machi_koro.card_effects.landmarks.shopping_mall import ShoppingMall
from machi_koro.card_effects.landmarks.amusement_park import AmusementPark
from machi_koro.card_effects.landmarks.radio_tower import RadioTower


class Game():
    """Game object
    """

    def __init__(self, game_id, players: Iterable[Player], game_type: GameType = GameType.BASEGAME, deck_cards_low_revealed=4, deck_cards_high_revealed=4, deck_cards_major_revealed=2):
        self.game_id = game_id
        self.dice1 = Dice()
        self.dice2 = Dice()
        self.players = deque(players)
        self.active_player = self.players[0]
        self.game_type = game_type
        self.lower_card_deck = self.__create_lower_card_deck(
            deck_cards_low_revealed)
        self.higher_card_deck = self.__create_higher_card_decks(
            deck_cards_high_revealed)
        self.major_card_deck = self.__create_major_card_decks(
            deck_cards_major_revealed)
        self.number_of_turns = 1
        self.number_of_orbits = 1

        for player in self.players:
            player.game = self

            player.building_cards = [
                PrimaryIndustryCard(
                    "Wheat Field", construction_cost=1, activation_number=1, card_icon=CardIcon.WHEAT, card_effect=CardEffectPrimary(1)),
                SecondaryIndustryCard(
                    "Bakery", construction_cost=1, activation_number=[2, 3], card_icon=CardColor.GREEN, card_effect=CardEffectSeconday(1))
            ]
            player.landmark_cards = [
                LandmarkCard(
                    "Train Station", effect=TrainStation(), completion_cost=4),
                LandmarkCard(
                    "Shopping Mall", effect=ShoppingMall(), completion_cost=10),
                LandmarkCard(
                    "Amusement Park", effect=AmusementPark(), completion_cost=16),
                LandmarkCard(
                    "Radio Tower", effect=RadioTower(), completion_cost=22)
            ]
            player.gold_amount = 3

    def __create_lower_card_deck(self, deck_cards_revealed):
        return CardDeckCreator.create_low(self, deck_cards_revealed)

    def __create_higher_card_decks(self, deck_cards_revealed):
        return CardDeckCreator.create_high(self, deck_cards_revealed)

    def __create_major_card_decks(self, deck_cards_revealed):
        return CardDeckCreator.create_major(self, deck_cards_revealed)

    def next_player_turn(self):
        self.players.rotate(-1)
        self.active_player = self.players[0]

    def roll_dice(self):
        dices = list(Dice)
        dices.append(self.dice1)
        can_throw_with_two_dices = self.active_player.can_throw_with_two_dices()
        if can_throw_with_two_dices:
            with_2_dices = self.active_player.choice_two_dices()
            if with_2_dices:
                dices.append(self.dice2)

        return DiceRoll(dices)

    def get_active_buyable_establishments(self):
        buyable_establishments = list()
        for card in self.lower_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.gold_amount:
                buyable_establishments.append(card)

        for card in self.higher_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.gold_amount:
                buyable_establishments.append(card)

        for card in self.major_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.gold_amount:
                buyable_establishments.append(card)

        return buyable_establishments

    def get_active_buyable_landmarks(self):
        buyable_landmarks = list()
        for landmark_card in self.active_player.landmark_cards:
            if not landmark_card.is_constructed and landmark_card.completion_cost <= self.active_player.gold_amount:
                buyable_landmarks.append(landmark_card)
        return buyable_landmarks

    def give_establishment_card_to_player(self, card_to_give: EstablishmentBase):
        self.active_player.receive_establishment(card_to_give)
        deck = card_to_give.deck
        deck.remove_card(card_to_give)
        deck.reveal_top_card()

    def play_turn(self, dice_number=None):

        dice_roll = None
        if dice_number is None:
            dice_roll = self.roll_dice()
            dice_number = dice_roll.total()

        self.earn_income_restaurants(dice_number)
        self.earn_income_primary(dice_number)
        self.earn_income_secondary(dice_number)
        self.earn_income_major_establishment(dice_number)

        # build stage
        # filter revealed cards for purchase for player
        establishments = self.get_active_buyable_establishments()
        landmarks = self.get_active_buyable_landmarks()
        if len(establishments) != 0 and len(landmarks) != 0:
            card_to_buy = self.active_player.choice_build(
                establishments, landmarks)
            if isinstance(card_to_buy, LandmarkCard):
                self.active_player.amount_gold = self.active_player.amount_gold - card_to_buy.cost
                card_to_buy.is_constructed = True
            elif isinstance(card_to_buy, EstablishmentBase):
                self.active_player.amount_gold = self.active_player.amount_gold - card_to_buy.cost
                self.give_establishment_card_to_player(card_to_buy)

        if(self.is_winner()):
            return

        self.next_player_turn()

        landmark = LandmarkCard
        landmark.name = 'Amusement Park'

        if dice_roll.is_same() and self.active_player.is_constructed_landmark(landmark):
            return

    def end_turn(self):
        self.number_of_turns = self.number_of_turns + 1

        if self.active_player.player_id == 1:
            self.number_of_orbits = self.number_of_orbits + 1

    def check_for_winner(self):
        pass

    def start(self):

        while True:
            # play_turn()
            # check_for_winner()
            # next_player_turn()

            print("self.number_of_turns: ", self.number_of_turns)
            print("self.number_of_orbits: ", self.number_of_orbits)

    def earn_income_restaurants(self, dice_number):
        for player in self.players:
            if player is not self.active_player:
                for restaurant in player.get_restaurant_cards():
                    if restaurant.activation == dice_number:
                        restaurant.card_effect.activate(
                            player, self.active_player)

                    if self.active_player.gold_amount == 0:
                        break

    def earn_income_primary(self, dice_number):
        for player in self.players:
            for primary_card in player.get_primary_cards():
                if primary_card.activation_number == dice_number:
                    primary_card.card_effect.activate(player)

    def earn_income_secondary(self, dice_number):
        for secondary_card in self.active_player.get_secondary_cards():
            if (dice_number in secondary_card.activation_number) or (secondary_card.activation_number == dice_number):
                secondary_card.card_effect.activate(self.active_player)

    def earn_income_major_establishment(self, dice_number):
        for restaurant_card in self.active_player.get_restaurant_cards():
            if restaurant_card.activation_number == dice_number:
                restaurant_card.card_effect.activate()

    def is_winner(self):

        if all(landmark.is_constructed == True for landmark in self.active_player.landmark_cards):
            # game ends, this player wins the game
            print("Player: " + str(self.active_player.player_id) +
                  " " + self.active_player.name + "WINS!")
            return True
        return False
