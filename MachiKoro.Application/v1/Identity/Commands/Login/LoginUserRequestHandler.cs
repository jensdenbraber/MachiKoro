using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity.Commands.Login;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IIdentityService _identityService;

    public LoginUserRequestHandler(IIdentityService identityService)
    {
        _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        var createUserResponse = new LoginUserResponse();

        try
        {
            var result = await _identityService.AuthorizeAsync(request.UserName, request.Password, request.IpAddress);

            createUserResponse.UserId = result.UserId;
            createUserResponse.UserName = result.UserName;
            createUserResponse.Token = result.Token;
            createUserResponse.RefreshToken = result.RefreshToken;
        }
        catch (Exception)
        {
            throw;
        }

        return createUserResponse;
    }
}