using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class BaseProvider : IDisposable
{
    private IConfiguration Configuration { get; set; }

    public BaseProvider(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IDbConnection connection;
    protected IDbConnection Connection => connection ??= new SqlConnection(Configuration.GetConnectionString("Store"));

    public void Dispose()
    {
        if (Connection != null)
            Connection.Dispose();
    }
}