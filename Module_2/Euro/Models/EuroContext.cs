using Microsoft.EntityFrameworkCore;

namespace Euro.Models;

public class EuroContext : DbContext
{
    public EuroContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Club> Club { get; set; }
    public DbSet<Round> Round { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Match> Match { get; set; }
    public DbSet<Soccer> Soccer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Match>().HasOne(p => p.Team1).WithMany(p => p.TeamMatches1).HasForeignKey(p => p.TeamId1);
        modelBuilder.Entity<Match>().HasOne(p => p.Team2).WithMany(p => p.TeamMatches2).HasForeignKey(p => p.TeamId2);
    }
}