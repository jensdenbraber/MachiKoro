using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.Identity
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
