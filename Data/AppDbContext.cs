using Microsoft.EntityFrameworkCore;
using Bill_Generate.Models;  // Ensure you are using the correct namespace

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillItem> BillItems { get; set; }
}
