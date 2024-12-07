using System.Data;
using Dapper;
using WebApi.Model;

namespace WebApi.Repository;

public class AccessRoleRepository : BaseRepository
{
    public AccessRoleRepository(IDbConnection connection) : base(connection)
    {
    }

    public int Save(AccessRole obj)
    {
        return Connection.Execute("SaveAccessRole", obj, commandType: CommandType.StoredProcedure);
    }
}