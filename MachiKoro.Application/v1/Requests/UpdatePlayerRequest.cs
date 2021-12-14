using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Application.v1.Requests
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}
