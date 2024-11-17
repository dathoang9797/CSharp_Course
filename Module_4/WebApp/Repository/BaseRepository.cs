using System.Data;

namespace WebApp.Repository;

public abstract class BaseRepository
{
    protected IDbConnection Connection { get; set; }
    protected Uri BaseUri { get; set; }

    public BaseRepository(IDbConnection connection, IConfiguration configuration)
    {
        Connection = connection;
        BaseUri = new Uri(configuration["ApiUrl"] ?? throw new Exception("Not foudn ApiUrl"));
    }
}