using MachiKoro.Utilities;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Contracts.v1.Requests
{
    public class CreateGameRequest
    {
        [Required]
        [Range(2, 5)]
        public int MaxNumberOfPlayers { get; set; }

        [Required]
        public ExpensionType ExpensionType { get; set; }
    }
}
