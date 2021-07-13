using MachiKoro.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MachiKoro.Data
{
    public class PlayerDataContext : DbContext
    {
        public PlayerDataContext(DbContextOptions<PlayerDataContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerProfile> PlayersProfiles { get; set; }

        public DbSet<PlayersStatistics> PlayersStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerProfile)
                .WithOne(pp => pp.Player)
                .HasForeignKey<PlayerProfile>(ppp => ppp.PlayerForeignKey);

            modelBuilder.Entity<PlayerProfile>()
                .HasOne(p => p.PlayersStatistics)
                .WithOne(pp => pp.PlayerProfile)
                .HasForeignKey<PlayersStatistics>(ppp => ppp.PlayerProfileForeignKey);

            base.OnModelCreating(modelBuilder);
        }
    }
}
