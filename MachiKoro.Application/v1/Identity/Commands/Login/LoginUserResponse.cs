namespace MachiKoro.Application.v1.Identity.Commands.Login;

public class LoginUserResponse
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}