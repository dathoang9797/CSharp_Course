using System.Data;
using System.Data.SqlClient;

namespace WebApp.Models;

public class BaseProvider : IDisposable
{
    private IDbConnection? connection;
    protected IConfiguration Configuration;
    public BaseProvider(IConfiguration configuration) => Configuration = configuration;
    protected IDbConnection Connection => connection ??= new SqlConnection(Configuration.GetConnectionString("Koi"));
    protected IDbConnection ConnectionStore => connection ??= new SqlConnection(Configuration.GetConnectionString("Koi"));

    public void Dispose()

    {
        Console.WriteLine("Disposable");
        connection?.Dispose();
    }
}