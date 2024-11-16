using System.Data;

namespace WebApi.Repository;

public abstract class BaseRepository
{
    protected IDbConnection Connection { get; set; }

    public BaseRepository(IDbConnection connection)
    {
        Connection = connection;
    }
}