using Microsoft.EntityFrameworkCore;

namespace WebAppVNPayment.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options) { }
    public DbSet<VnPaymentResponse> VnPaymentResponses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Cart { get; set; }

}