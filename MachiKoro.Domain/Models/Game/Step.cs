using MachiKoro.Domain.Enums;
using System;

namespace MachiKoro.Domain.Models.Game
{
    public class Step
    {
        public Guid PlayerId { get; set; }
        public StepKind StepKind { get; set; }
        public int Type { get; set; }
        public object Result { get; set; }
    }
}