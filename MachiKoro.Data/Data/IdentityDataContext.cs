using MachiKoro.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MachiKoro.Data
{
    public class IdentityDataContext : IdentityDbContext
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
            : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
