using System.ComponentModel;

namespace MachiKoro.Domain.Enums;

public enum CardCategory
{
    [Description("Wheat")]
    Wheat = 1,

    [Description("Bread")]
    Bread = 2,

    [Description("Cow")]
    Cow = 3,

    [Description("Cup")]
    Cup = 4,

    [Description("Gear")]
    Gear = 5,

    [Description("Fruit")]
    Fruit = 6,

    [Description("Tower")]
    Tower = 7,

    [Description("Factory")]
    Factory = 8
}