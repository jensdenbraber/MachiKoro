using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MachiKoro.Persistence
{
    public class GameDataContext : DbContext
    {
        public GameDataContext(DbContextOptions<GameDataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Step> Steps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>()
            //    .Property(x => x.ExpensionType)
            //    .HasConversion<int>();

            modelBuilder.Entity<Game>()
                .HasMany<Player>(p => p.Players)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GamePlayer"));

            // configures one-to-many relationship
            modelBuilder.Entity<Game>()
                .HasMany<Step>(s => s.Step)
                .WithOne(g => g.Game)
                .HasForeignKey(s => s.GameId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        //public override int SaveChanges()
        //{
        //    var now = DateTime.UtcNow;
        //    foreach (var item in ChangeTracker.Entries<Game>()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        //    {
        //        item.Property("CreatedTime").CurrentValue = now;
        //    }
        //    return base.SaveChanges();
        //}
    }
}