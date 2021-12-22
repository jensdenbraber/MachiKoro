using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MachiKoro.Persistence
{
    public class PlayerDataContext : DbContext
    {
        public PlayerDataContext(DbContextOptions<PlayerDataContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        //public DbSet<PlayerProfile> PlayersProfiles { get; set; }

        //public DbSet<PlayersStatistics> PlayersStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Game>()
                .HasOne<Player>(s => s.Player)
                .WithMany(g => g.Games)
                .HasForeignKey(s => s.PlayerId);
        }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Player>()
    //        .HasOne(p => p.PlayerProfile)
    //        .WithOne(pp => pp.Player)
    //        .HasForeignKey<PlayerProfile>(ppp => ppp.PlayerForeignKey);

    //    modelBuilder.Entity<PlayerProfile>()
    //        .HasOne(p => p.PlayersStatistics)
    //        .WithOne(pp => pp.PlayerProfile)
    //        .HasForeignKey<PlayersStatistics>(ppp => ppp.PlayerProfileForeignKey);

    //    base.OnModelCreating(modelBuilder);
    //}
}
}
