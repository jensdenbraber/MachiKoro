using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Game;

public class Question
{
    public Enums.ChoiceType ChoiceType { get; set; }
    public List<object> Options { get; set; }
}