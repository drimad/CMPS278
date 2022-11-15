using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Car> Cars { get; set; } = null!;

}