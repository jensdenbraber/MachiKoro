using MachiKoro.Application.v1.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh;

public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
{
    private readonly IIdentityService _identityService;

    public RefreshTokenRequestHandler(IIdentityService identityService)
    {
        _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
    }

    public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        var result = await _identityService.RefreshToken(request.Token, request.IpAddress);

        var refreshTokenResponse = new RefreshTokenResponse
        {
            JwtToken = request.Token,
            RefreshToken = result.RefreshToken
        };

        return refreshTokenResponse;
    }
}