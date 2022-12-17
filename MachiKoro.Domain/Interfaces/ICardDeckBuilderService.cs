using MachiKoro.Domain.Models.CardDecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Domain.Interfaces;

public interface ICardDeckBuilderService
{
    List<CardDeck> BuildCardDecksBasicGame(int revealedLowCards = 4, int revealedHighCards = 4, int revealedMajorCards = 2);
}
