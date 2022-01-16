using MachiKoro.Core.Models.Identity;
using MediatR;

namespace MachiKoro.Application.v1.Identity.Commands.Registration
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
