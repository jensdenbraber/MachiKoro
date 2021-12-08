using MediatR;

namespace MachiKoro.Core.Models.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}
