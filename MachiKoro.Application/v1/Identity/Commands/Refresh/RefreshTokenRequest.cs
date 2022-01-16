using FluentValidation;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}