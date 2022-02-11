using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Contracts.Identity.Login
{
    public record LoginUserResponse
    {
        public string Token { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }
}