using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppAuthentication.Model;

public class StoreContext : IdentityDbContext
{
    public StoreContext(DbContextOptions options) : base(options) { }

    public DbSet<Member> Members { get; set; }
}