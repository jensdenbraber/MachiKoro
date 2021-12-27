using MachiKoro.Application.v1.Game.Commands.Choose;
using MediatR;

namespace MachiKoro.Api.Contracts.Game.Choose
{
    public class ChooseRequest
    {
        public int Index { get; set; }
    }
}