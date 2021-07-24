using MachiKoro.Core;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Api.Models.CreateGame
{
    public class CreateGameRequest
    {
        [Required]
        public int MaxNumberOfPlayers { get; set; }
        [Required]
        public ExpensionType ExpensionType { get; set; }
    }
}
