using System;
using System.Collections.Generic;

namespace MachiKoro.Core.Models.Identity
{
    public class CreateUserResponse
    {
        public Guid? UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Errors { get; set; }
    }
}
