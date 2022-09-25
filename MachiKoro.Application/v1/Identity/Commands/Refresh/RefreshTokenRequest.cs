using MediatR;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh;

public class RefreshTokenRequest : IRequest<RefreshTokenResponse>
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }
    public string IpAddress { get; set; }
}