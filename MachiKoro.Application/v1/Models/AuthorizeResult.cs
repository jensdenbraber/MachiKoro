namespace MachiKoro.Application.v1.Models
{
    public class AuthorizeResult
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}