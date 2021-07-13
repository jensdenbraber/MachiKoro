using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Contracts.v1.Requests
{
    public class CreatePlayerRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}
