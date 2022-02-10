using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Identity.Models
{
    public class RefreshToken
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime Expiry { get; set; }

        public bool IsExpired
        {
            get { return DateTime.UtcNow >= Expiry; }
        }

        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string ReasonRevoked { get; set; }

        public bool IsActive
        {
            get { return Revoked == null && !IsExpired; }
        }

        public string UserId { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User { get; set; }
    }
}