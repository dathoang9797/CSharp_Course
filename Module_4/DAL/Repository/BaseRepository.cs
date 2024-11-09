using System.Data;

namespace DAL;

public abstract class BaseRepository
{
    //constructor internal vs public
    protected IDbConnection Connection { get; set; }

    internal BaseRepository(IDbConnection connection)
    {
        Connection = connection;
    }
}