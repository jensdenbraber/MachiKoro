using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Cards.Landmarks.Basic;
using System;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Player;

public class Player
{
    public Guid Id { get; set; }
    public PlayerType PlayerType { get; set; }
    public int CoinAmount { get; set; }
    public List<EstablishmentBase> EstablishmentCards { get; set; }
    public List<LandMark> LandmarkCards { get; set; }

    public Player()
    {
    }

    public Player(Guid id, PlayerType playerType, int coinAmount, List<EstablishmentBase> establishmentCards, List<LandMark> landmarkCards)
    {
        Id = id;
        PlayerType = playerType;
        CoinAmount = coinAmount;
        EstablishmentCards = establishmentCards;
        LandmarkCards = landmarkCards;
    }
}