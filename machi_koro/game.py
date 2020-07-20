import machi_koro.player as player

import machi_koro.utils as utils
import machi_koro.card_deck_factory as CardDeckCreator
import machi_koro.dice as dice

import machi_koro.cards.landmark_card as landmark_card
import machi_koro.cards.primary_industry as primary_industry
import machi_koro.cards.secondary_industry as secondary_industry
import machi_koro.cards.major_establishment as major_establishment

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

    def __init__(self, game_id, players: (player.Player), game_type: utils.GameType, deck_cards_low_revealed=4, deck_cards_high_revealed=4, deck_cards_major_revealed=2):
        self.game_id = game_id
        self.players = collections.deque(players)
        self.active_player = self.players[0]
        self.game_type = game_type
        self.lower_card_deck = self.__create_lower_card_deck(
            deck_cards_low_revealed)
        self.higher_card_deck = self.__create_higher_card_decks(
            deck_cards_high_revealed)
        self.major_card_deck = self.__create_major_card_decks(
            deck_cards_major_revealed)

    def __create_lower_card_deck(self, deck_cards_revealed):
        return CardDeckCreator.CardDeckCreator.create_low(self, deck_cards_revealed)

    def __create_higher_card_decks(self, deck_cards_revealed):
        return CardDeckCreator.CardDeckCreator.create_high(self, deck_cards_revealed)

    def __create_major_card_decks(self, deck_cards_revealed):
        return CardDeckCreator.CardDeckCreator.create_major(self, deck_cards_revealed)

    def next_player_turn(self):
        self.players.rotate(-1)
        self.active_player = self.players[0]

    def start(self):
        for p in self.players:
            p.building_cards = [primary_industry.PrimaryIndustryCard("Wheat Field", 1, 1, utils.CardIcon.WHEAT, card_effect_primary.CardEffectPrimary(1)),
                                secondary_industry.SecondaryIndustryCard(
                "Bakery", 1, [2, 3], utils.Color.GREEN, card_effect_secondary.CardEffectSeconday(1))
            ]
            p.landmark_cards = [landmark_card.LandmarkCard("Train Station", train_station_effect.TrainStation(), 4, False),
                                landmark_card.LandmarkCard(
                "Shopping Mall", shopping_mall_effect.ShoppingMall(), 10, False),
                landmark_card.LandmarkCard(
                "Amusement Park", amusement_park_effect.AmusementPark(), 16, False),
                landmark_card.LandmarkCard(
                "Radio Tower", radio_tower_effect.RadioTower(), 22, False)
            ]
            p.gold_amount = 3

        d = dice.Dice()
        while True:
            dice_number = self.active_player.roll_dice(d)

            self.earn_income_restaurants(dice_number)
            self.earn_income_primary(dice_number)
            self.earn_income_secondary(dice_number)
            self.earn_income_major_establishment(dice_number)

            if(self.check_for_winner()):
                break

            self.next_player_turn()

        return

    def earn_income_restaurants(self, dice_number):
        for p in self.players:
            if p is not self.active_player:
                for restaurant in p.get_restaurant_cards():
                    if restaurant.activation == dice_number:
                        restaurant.activation(p, self.active_player)

                    if self.active_player.gold_amount == 0:
                        break

    def earn_income_primary(self, dice_number):
        for p in self.players:
            for primary_card in p.get_primary_cards():
                if primary_card.activation_number == dice_number:
                    primary_card.activation(p, p.gold_amount)

    def earn_income_secondary(self, dice_number):
        for secondary_card in self.active_player.get_secondary_cards():
            if (dice_number in secondary_card.activation_number) or (secondary_card.activation_number == dice_number):
                secondary_card.activation(self.active_player)

    def earn_income_major_establishment(self, dice_number):
        for restaurant_card in self.active_player.get_restaurant_cards():
            if restaurant_card.activation_number == dice_number:
                restaurant_card.activation()

    def check_for_winner(self):
        if all(self.active_player.landmark_cards):
            # game ends, this player wins the game
            print("Player: " + str(self.active_player.player_id) +
                  " " + self.active_player.name + "WINS!")
