using System.Data;
using System.Data.SqlClient;
using WebApi.Repository;

namespace WebApi.Model;

public class SiteProvider
{
    private IDbConnection? connection;
    private IConfiguration Configuration { get; set; }

    public SiteProvider(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected IDbConnection Connection => connection ??= new SqlConnection(Configuration.GetConnectionString("WebApi"));

    private CategoryRepository category;
    public CategoryRepository Category => category ??= new CategoryRepository(Connection);
    
    private ProductRepository product;
    public ProductRepository Product => product ??= new ProductRepository(Connection);
}