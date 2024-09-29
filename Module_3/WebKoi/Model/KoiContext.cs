using Microsoft.EntityFrameworkCore;
using WebKoi.Model;

namespace WebAppAuthentication.Model;

public class KoiContext : DbContext
{
    public KoiContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Business> Business { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<NumberOfOrder> NumberOfOrders { get; set; }
    public DbSet<Article> Article { get; set; }
    public DbSet<Member> Member { get; set; }
}