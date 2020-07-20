import unittest
import machi_koro.card_deck_factory as CardDeckCreator


class CardDecks(unittest.TestCase):
    def revealed_deck_low(self):
        number_of_cards = len(
            CardDeckCreator.CardDeckCreator.create_low(self, 0).cards)
        for i in range(number_of_cards):
            card_deck = CardDeckCreator.CardDeckCreator.create_low(self, i)
            self.assertEqual(card_deck.revealed_cards, i)
            self.assertEqual(card_deck.cards, number_of_cards - i)

    def revealed_deck_high(self):
        number_of_cards = len(
            CardDeckCreator.CardDeckCreator.create_high(self, 0).cards)
        for i in range(number_of_cards):
            card_deck = CardDeckCreator.CardDeckCreator.create_high(self, i)
            self.assertEqual(card_deck.revealed_cards, i)
            self.assertEqual(card_deck.cards, number_of_cards - i)

    def revealed_deck_major(self):
        number_of_cards = len(
            CardDeckCreator.CardDeckCreator.create_major(self, 0).cards)
        for i in range(number_of_cards):
            card_deck = CardDeckCreator.CardDeckCreator.create_major(self, i)
            self.assertEqual(card_deck.revealed_cards, i)
            self.assertEqual(card_deck.cards, number_of_cards - i)

    def category_cards_low(self):
        cards = CardDeckCreator.CardDeckCreator.create_low(self, 0).cards
