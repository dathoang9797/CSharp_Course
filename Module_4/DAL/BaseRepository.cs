using System.Data;

namespace DAL;

public abstract class BaseRepository
{
    protected IDbConnection Connection { get; set; }

    public BaseRepository(IDbConnection connection)
    {
        Connection = connection;
    }
}