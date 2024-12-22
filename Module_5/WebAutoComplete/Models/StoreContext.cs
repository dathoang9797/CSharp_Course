using Microsoft.EntityFrameworkCore;

namespace WebAutoComplete.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
}