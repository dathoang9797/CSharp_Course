using System.Data;

namespace WebApp.Repository;

public abstract class BaseRepository
{
    protected IDbConnection Connection { get; set; }

    public BaseRepository(IDbConnection connection)
    {
        Connection = connection;
    }
}