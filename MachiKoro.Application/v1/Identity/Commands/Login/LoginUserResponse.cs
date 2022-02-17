using System;
using System.Collections.Generic;

namespace MachiKoro.Application.v1.Identity.Commands.Login
{
    public class LoginUserResponse
    {
        public Guid? UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Errors { get; set; }
    }
}
