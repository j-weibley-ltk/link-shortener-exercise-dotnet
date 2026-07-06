using LinkShortener.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinkShortener.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Link> Links => Set<Link>();
    public DbSet<Click> Clicks => Set<Click>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Click>()
            .HasOne(c => c.Link)
            .WithMany(l => l.Clicks)
            .HasForeignKey(c => c.LinkId);

        var utc = new ValueConverter<DateTime, DateTime>(
            v => v,
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        modelBuilder.Entity<Link>().Property(l => l.CreatedAt).HasConversion(utc);
        modelBuilder.Entity<Click>().Property(c => c.CreatedAt).HasConversion(utc);
    }
}
