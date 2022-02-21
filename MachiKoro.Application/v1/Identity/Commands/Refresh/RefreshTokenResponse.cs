using FluentValidation;
using System.Text.Json.Serialization;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh
{
    public class RefreshTokenResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }
}