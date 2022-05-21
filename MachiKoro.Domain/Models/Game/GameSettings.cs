using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Cards.Landmarks.Basic;
using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Game;

public class GameSettings
{
    public List<LandMark> StartingLandmarkCards { get; set; }
    public List<EstablishmentBase> StartingEstablishmentCards { get; set; }

    public GameSettings()
    {
        StartingLandmarkCards = new List<LandMark>()
        {
            new LandMark("Train Station", CardCategory.Tower, 4, null),
            new LandMark("Shopping Mall", CardCategory.Tower, 10, null),
            new LandMark("Amusement Park", CardCategory.Tower, 16, null),
            new LandMark("Radio Tower", CardCategory.Tower, 22, null),
        };

        StartingEstablishmentCards = new List<EstablishmentBase>()
        {
            new PrimaryIndustry("Wheat Field", CardCategory.Wheat, new List<int>() { 1 }, 1, null),
            new SecondaryIndustryCard("Bakery", CardCategory.Bread, new List<int>() { 2, 3 }, 1, null),
        };
    }
}