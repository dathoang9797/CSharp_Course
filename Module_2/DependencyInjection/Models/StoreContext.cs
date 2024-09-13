using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Models;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
        Console.WriteLine("Context Constructor");
    }
}