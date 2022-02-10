namespace MachiKoro.Api.Contracts.Identity.RefreshToken
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
