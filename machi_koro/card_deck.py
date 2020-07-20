

class CardDeck():
    def __init__(self, establishment_cards, max_number_revealed):
        self.cards = establishment_cards
        self.revealed_cards = self.cards[0:max_number_revealed]
        del self.cards[0:max_number_revealed]

    def reveal_top_card(self):
        self.reveal_top_card = self.cards.pop()
