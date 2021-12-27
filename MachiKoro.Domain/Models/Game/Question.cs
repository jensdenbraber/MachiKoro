using System.Collections.Generic;

namespace MachiKoro.Domain.Models.Game
{
    public class Question
    {
        public Enums.ChoiseType ChoiseType { get; set; }
        public List<object> Options { get; set; }
    }
}