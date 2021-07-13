using MachiKoro.Utilities;
using MediatR;

namespace MachiKoro.Core.Models.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public int MaxNumberOfPlayers { get; set; }

        public ExpensionType ExpensionType { get; set; }

        public CreateGameRequest(int maxNumberOfPlayers, ExpensionType expensionType)
        {
            MaxNumberOfPlayers = maxNumberOfPlayers;
            ExpensionType = expensionType;
        }
    }
}
