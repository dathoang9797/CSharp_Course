using System.Data;
using System.Data.SqlClient;

namespace WebAppChat.Models;

public class BaseProvider : IDisposable
{
    private IDbConnection? connection;
    private IConfiguration Configuration;
    public BaseProvider(IConfiguration configuration) => Configuration = configuration;
    protected IDbConnection Connection => connection ??= new SqlConnection(Configuration.GetConnectionString("WebChat"));

    public void Dispose()

    {
        connection?.Dispose();
    }
}