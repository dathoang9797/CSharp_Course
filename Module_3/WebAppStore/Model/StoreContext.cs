using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppStore.Model;

public class StoreContext : IdentityDbContext
{
    public StoreContext(DbContextOptions options) : base(options) { }
}