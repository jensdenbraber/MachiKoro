using System.Collections.Generic;

namespace MachiKoro.Api.Contracts.Identity.Registration
{
    public record CreateUserResponse
    {
        public string Token { get; set; }
        public List<string> Errors { get; set; }
    }
}