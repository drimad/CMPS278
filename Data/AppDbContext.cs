using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Car> Cars { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Car>().Property(p => p.NumberOfDoors)
        .HasPrecision(18, 2); // fluent validation
    }
}