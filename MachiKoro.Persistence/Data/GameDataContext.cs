using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MachiKoro.Persistence.Data;

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

        //modelBuilder.Entity<GamePlayer>()
        //        .HasOne<Game>(sc => sc.Game)
        //        .WithMany(s => s.GamePlayers)
        //        .HasForeignKey(sc => sc.GameId);

        //modelBuilder.Entity<GamePlayer>()
        //        .HasOne<Player>(sc => sc.Player)
        //        .WithMany(s => s.GamePlayers)
        //        .HasForeignKey(sc => sc.PlayerId);

        //modelBuilder.Entity<Game>()
        //    .HasMany<Player>(p => p.Players)
        //    .WithMany(g => g.Games)
        //    .UsingEntity(j => j.ToTable("GamePlayer"))
        //    .HasKey(t => new { t.GamesId, g.t.PlayerId });

        modelBuilder.Entity<Game>()
            .HasMany(p => p.Players)
            .WithMany(g => g.Games)
            .UsingEntity<GamePlayer>(
                        j => j
                           .HasOne(pt => pt.Player)
                           .WithMany(t => t.GamePlayers)
                           .HasForeignKey(pt => pt.PlayersId),
                        j => j
                            .HasOne(pt => pt.Game)
                            .WithMany(p => p.GamePlayers)
                            .HasForeignKey(pt => pt.GamesId),
                        j =>
                        {
                            j.HasKey(t => new { t.GamesId, t.PlayersId });
                        });

        //modelBuilder.Entity<Game>()
        //    .HasMany<Player>(p => p.Step)
        //    .WithOne(g => g.Game)
        //    .HasForeignKey(s => s.GameId)
        //    .IsRequired();

        //modelBuilder.Entity<Game>()
        //    .HasMany<Player>(p => p.Players)
        //    .WithMany(g => g.Games)
        //    .UsingEntity(j => j.ToTable("GamePlayer").HasKey(t => t  new { t.GamesId, t.TagId }));

        //t => new { t. } "GamesId", "PlayersId"));

        // configures one-to-many relationship
        modelBuilder.Entity<Game>()
            .HasMany(s => s.Step)
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