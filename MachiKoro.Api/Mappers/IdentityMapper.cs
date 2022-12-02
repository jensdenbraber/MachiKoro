using MachiKoro.Api.Contracts.Identity.Login;
using MachiKoro.Api.Contracts.Identity.RefreshToken;
using MachiKoro.Api.Contracts.Identity.Registration;

namespace MachiKoro.Api.Mappers;

public static class IdentityMapper
{
    public static Application.v1.Identity.Commands.Registration.CreateUserRequest ToCore(this CreateUserRequest createUserRequest)
    {
        return new Application.v1.Identity.Commands.Registration.CreateUserRequest
        {
            UserName = createUserRequest.UserName,
            Email = createUserRequest.Email,
            Password = createUserRequest.Password,
        };
    }

    public static Application.v1.Identity.Commands.Login.LoginUserRequest ToCore(this LoginUserRequest loginUserRequest)
    {
        return new Application.v1.Identity.Commands.Login.LoginUserRequest
        {
            UserName = loginUserRequest.UserName,
            Password = loginUserRequest.Password
        };
    }

    public static Application.v1.Identity.Commands.Refresh.RefreshTokenRequest ToCore(this RefreshTokenRequest refreshTokenRequest)
    {
        return new Application.v1.Identity.Commands.Refresh.RefreshTokenRequest
        {
            RefreshToken = refreshTokenRequest.RefreshToken,
            Token = refreshTokenRequest.Token
        };
    }

    public static LoginUserResponse ToApi(this Application.v1.Identity.Commands.Registration.CreateUserRequest createUserRequest)
    {
        return new LoginUserResponse
        {
            UserName = createUserRequest.UserName,
        };
    }

    public static LoginUserResponse ToApi(this Application.v1.Identity.Commands.Login.LoginUserResponse loginUserRequest)
    {
        return new LoginUserResponse
        {
            UserName = loginUserRequest.UserName,
        };
    }

    public static RefreshTokenResponse ToApi(this Application.v1.Identity.Commands.Refresh.RefreshTokenResponse refreshTokenRequest)
    {
        return new RefreshTokenResponse
        {
            RefreshToken = refreshTokenRequest.RefreshToken,
        };
    }
}