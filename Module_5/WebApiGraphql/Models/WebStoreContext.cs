using Microsoft.EntityFrameworkCore;

namespace WebApiGraphql.Models;

public class WebStoreContext : DbContext
{
    public WebStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
}