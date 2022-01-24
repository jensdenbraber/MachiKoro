using System;

namespace MachiKoro.Application.v1.Game.Commands.Choices
{
    public class SwapChoice : Choice
    {
        public Guid TargetACardId { get; set; }
        public Guid TargetBCardId { get; set; }
    }
}