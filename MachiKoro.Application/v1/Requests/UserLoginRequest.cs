using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Application.v1.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}