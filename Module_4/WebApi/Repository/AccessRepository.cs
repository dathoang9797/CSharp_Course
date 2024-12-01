using System.Data;
using Dapper;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Repository;

public class AccessRepository : BaseRepository
{
    public AccessRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Access> GetAccesses()
    {
        const string sql = "SELECT * FROM Access";
        var rsp = Connection.Query<Access>(sql);
        return rsp;
    }
}