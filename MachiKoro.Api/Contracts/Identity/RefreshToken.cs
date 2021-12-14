using Microsoft.AspNetCore.Identity;
using System;

namespace MachiKoro.Api.Contracts.Identity
{
    public class RefreshToken
    {
        public string Token { get; set; }

        public string JwtId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool Used { get; set; }

        public bool Invalidated { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}