using MachiKoro.Domain.Enums;
using MediatR;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}
