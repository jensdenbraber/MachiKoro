import machi_koro.cards.landmark_card
from machi_koro.cards.primary_industry import PrimaryIndustryCard
import machi_koro.dice
import machi_koro.player as player

import machi_koro.utils as utils
import machi_koro.card_deck_factory as card_deck_factory
import machi_koro.dice as dice

import machi_koro.cards.landmark_card as landmark_card
import machi_koro.cards.primary_industry as primary_industry
import machi_koro.cards.secondary_industry as secondary_industry
import machi_koro.cards.major_establishment as major_establishment
import machi_koro.cards.establishment_base as establishment_base


import machi_koro.card_effects.establishments.primary as card_effect_primary
import machi_koro.card_effects.establishments.secondary as card_effect_secondary
import machi_koro.card_effects.landmarks.train_station as train_station_effect
import machi_koro.card_effects.landmarks.shopping_mall as shopping_mall_effect
import machi_koro.card_effects.landmarks.amusement_park as amusement_park_effect
import machi_koro.card_effects.landmarks.radio_tower as radio_tower_effect

import collections


class Game():
    """Game object
    """

    def __init__(self, game_id, players: (player.Player), game_type: utils.GameType = utils.GameType.BASEGAME, deck_cards_low_revealed=4, deck_cards_high_revealed=4, deck_cards_major_revealed=2):
        self.game_id = game_id
        self.dice1 = dice.Dice()
        self.dice2 = dice.Dice()
        self.players = collections.deque(players)
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

        for p in self.players:
            p.game = self

            p.building_cards = [
                primary_industry.PrimaryIndustryCard(
                    "Wheat Field", construction_cost=1, activation_number=1, card_icon=utils.CardIcon.WHEAT, card_effect=card_effect_primary.CardEffectPrimary(1)),
                secondary_industry.SecondaryIndustryCard(
                    "Bakery", construction_cost=1, activation_number=[2, 3], card_icon=utils.CardColor.GREEN, card_effect=card_effect_secondary.CardEffectSeconday(1))
            ]
            p.landmark_cards = [
                landmark_card.LandmarkCard(
                    "Train Station", effect=train_station_effect.TrainStation(), completion_cost=4),
                landmark_card.LandmarkCard(
                    "Shopping Mall", effect=shopping_mall_effect.ShoppingMall(), completion_cost=10),
                landmark_card.LandmarkCard(
                    "Amusement Park", effect=amusement_park_effect.AmusementPark(), completion_cost=16),
                landmark_card.LandmarkCard(
                    "Radio Tower", effect=radio_tower_effect.RadioTower(), completion_cost=22)
            ]
            p.gold_amount = 3

    def __create_lower_card_deck(self, deck_cards_revealed):
        return card_deck_factory.CardDeckCreator.create_low(self, deck_cards_revealed)

    def __create_higher_card_decks(self, deck_cards_revealed):
        return card_deck_factory.CardDeckCreator.create_high(self, deck_cards_revealed)

    def __create_major_card_decks(self, deck_cards_revealed):
        return card_deck_factory.CardDeckCreator.create_major(self, deck_cards_revealed)

    def next_player_turn(self):
        self.players.rotate(-1)
        self.active_player = self.players[0]

    def roll_dice(self):
        dices = list(dice.Dice)
        dices.append(self.dice1)
        can_throw_with_two_dices = self.active_player.can_throw_with_two_dices()
        if can_throw_with_two_dices:
            with_2_dices = self.active_player.choice_two_dices()
            if with_2_dices:
                dices.append(self.dice2)

        return dice.DiceRoll(dices)

    def get_active_buyable_establishments(self):
        buyable_cards = list()
        for card in self.lower_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.amount_gold:
                buyable_cards.append(card)

        for card in self.higher_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.amount_gold:
                buyable_cards.append(card)

        for card in self.major_card_deck.revealed_cards:
            if card.construction_cost <= self.active_player.amount_gold:
                buyable_cards.append(card)

        return buyable_cards

    def get_active_buyable_landmarks(self):
        buyable_cards = list()
        for landmark_card in self.active_player.landmark_cards:
            if not landmark_card.LandmarkCard.is_constructed and landmark_card.LandmarkCard.completion_cost <= self.active_player.amount_gold:
                buyable_cards.append(landmark_card.LandmarkCard)
        return buyable_cards

    def give_establishment_card_to_player(self, card_to_give: establishment_base.EstablishmentBase):
        self.active_player.receive_establishment(card_to_give)
        deck = card_to_give.deck
        deck.removeCard(card_to_give)
        deck.reveal_top_card()

    def play_turn(self, dice_number=None):

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
        if establishments.count() != 0 and landmarks.count() != 0:
            card_to_buy = self.active_player.choice_build(
                establishments, landmarks)
            if isinstance(card_to_buy, landmark_card.LandmarkCard):
                self.active_player.amount_gold = self.active_player.amount_gold - card_to_buy.cost
                card_to_buy.is_constructed = True
            elif isinstance(card_to_buy, establishment_base.EstablishmentBase):
                self.active_player.amount_gold = self.active_player.amount_gold - card_to_buy.cost
                give_establishment_card_to_player(card_to_buy)

        if(self.is_winner()):
            return

        self.next_player_turn()

        landmark = landmark_card.LandmarkCard
        landmark.name = 'Amusement Park'

        if dice_roll.is_same() and self.active_player.is_constructed_landmark(landmark):
            continue

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
        for p in self.players:
            if p is not self.active_player:
                for restaurant in p.get_restaurant_cards():
                    if restaurant.activation == dice_number:
                        restaurant.card_effect.activate(p, self.active_player)

                    if self.active_player.gold_amount == 0:
                        break

    def earn_income_primary(self, dice_number):
        for p in self.players:
            for primary_card in p.get_primary_cards():
                if primary_card.activation_number == dice_number:
                    primary_card.card_effect.activate(p)

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
