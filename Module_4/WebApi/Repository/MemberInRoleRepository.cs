using System.Data;
using Dapper;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Repository;

public class MemberInRoleRepository : BaseRepository
{
    public MemberInRoleRepository(IDbConnection connection) : base(connection)
    {
    }

    public int Save(MemberInRole obj)
    {
        return Connection.Execute("SaveMemberInRole", obj, commandType: CommandType.StoredProcedure);
    }
}