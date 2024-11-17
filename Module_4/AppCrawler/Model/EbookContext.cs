using Microsoft.EntityFrameworkCore;

namespace AppCrawler;

public class EbookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<BookAttribute> BookAttributes { get; set; }
    public DbSet<Attribute> Attributes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        const string connect = "server=localhost;user id=sa;password=<YourStrong@Passw0rd>;database=Ebook;Trusted_Connection=false;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connect);
    }
}