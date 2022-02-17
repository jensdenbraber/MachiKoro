using MachiKoro.Persistence.Identity.Models;

namespace MachiKoro.Persistence.Identity.Models.Authentication
{
    public class TokenResponse
    {
        public TokenResponse(string token,
                             string refreshToken
                            )
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string RefreshToken { get; set; }
    }
}
