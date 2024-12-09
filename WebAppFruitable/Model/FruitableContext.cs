using Microsoft.EntityFrameworkCore;
using WebAppFruitable.VnPayment;

namespace WebAppFruitable.Model;

public class FruitableContext : DbContext
{
    public FruitableContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Slide> Slide { get; set; }
    public DbSet<Testimonial> Testimonial { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<MemberEntity> Member { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<VnPaymentResponse> VnPaymentResponses { get; set; }
}