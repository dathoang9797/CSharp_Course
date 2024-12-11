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
    
    public Role? GetRole(int id)
    {
        const string sql = "SELECT * FROM Role WHERE RoleId = @Id";
        var rsp = Connection.QueryFirstOrDefault<Role>(sql, new { id });
        return rsp;
    }
}