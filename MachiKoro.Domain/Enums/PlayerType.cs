using System.ComponentModel;

namespace MachiKoro.Domain.Enums;

public enum PlayerType
{
    [Description("Human")]
    Human = 0,

    [Description("Computer")]
    Computer = 1
}