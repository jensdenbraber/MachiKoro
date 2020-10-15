class CardDeck():
    def __init__(self, establishment_cards, max_number_revealed):
        self.max_number_revealed = max_number_revealed
        self.cards = list(establishment_cards)
        self.revealed_cards = list(self.cards[0:max_number_revealed])
        self.last_revealed_card = self.revealed_cards[0] if len(
            self.revealed_cards) != 0 else None
        del self.cards[0:max_number_revealed]

    def reveal_top_card(self):
        if len(self.revealed_cards) <= self.max_number_revealed and len(self.cards) != 0:
            self.last_revealed_card = self.cards.pop()
            self.revealed_cards.append(self.last_revealed_card)

    def remove_card(self, card):
        if card in self.revealed_cards:
            self.revealed_cards.remove(card)

    def is_empty(self):
        return len(self.cards) == 0
