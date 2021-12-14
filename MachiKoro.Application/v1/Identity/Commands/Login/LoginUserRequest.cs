using MediatR;

namespace MachiKoro.Application.v1.Identity.Commands.Login
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
