using MachiKoro.Utilities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}
