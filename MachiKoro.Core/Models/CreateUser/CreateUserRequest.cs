using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
