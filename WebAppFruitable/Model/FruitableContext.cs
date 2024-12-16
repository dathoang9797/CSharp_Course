using Microsoft.EntityFrameworkCore;
using WebAppFruitable.VnPayment;

namespace WebAppFruitable.Model;

public class FruitableContext : DbContext
{
    public FruitableContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<VnPaymentResponse> VnPaymentResponses { get; set; }
}