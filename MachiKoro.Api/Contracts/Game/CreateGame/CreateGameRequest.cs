using MachiKoro.Domain.Enums;

namespace MachiKoro.Api.Contracts.Game.CreateGame
{
    public class CreateGameRequest
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}