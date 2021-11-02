using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Contracts.v1.Requests
{
    public class UserRegistrationRequest
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}