using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.Identity
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
