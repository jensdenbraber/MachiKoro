using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MachiKoro.Persistence
{
    public class GameDataContext : DbContext
    {
        public GameDataContext(DbContextOptions<GameDataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Game>()
        //        .Property(x => x.ExpensionType)
        //        .HasConversion<int>();

        //    //modelBuilder.Entity<Game>()
        //    //    .HasMany<ApplicationUser>(p => p.Players)
        //    //    .WithMany(g => g.Games)
        //    //    .UsingEntity(j => j.ToTable("GamePlayer"));

        //    base.OnModelCreating(modelBuilder);
        //}

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
