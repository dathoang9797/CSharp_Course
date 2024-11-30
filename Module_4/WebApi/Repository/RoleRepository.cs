using System.Data;
using Dapper;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Repository;

public class RoleRepository : BaseRepository
{
    public RoleRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Role> GetRoles()
    {
        return Connection.Query<Role>("SELECT * FROM Role");
    }

    public IEnumerable<RoleChecked> GetRolesByMember(string id)
    {
        return Connection.Query<RoleChecked>("GetRolesByMember", new { id }, commandType: CommandType.StoredProcedure);
    }
}