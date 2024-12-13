using System.Collections;
using System.Data;
using Dapper;
using WebApi.Model;

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

    public int Add(Access obj)
    {
        return Connection.Execute(
            "INSERT INTO Access(AccessName, AccessUrl, ParentId) VALUES (@AccessName, @AccessUrl, @ParentId)", obj);
    }

    public IEnumerable<Access> GetParents()
    {
        return Connection.Query<Access>("SELECT * FROM Access WHERE ParentId IS NULL");
    }

    public IEnumerable<AccessChecked> GetAccessesChecked(string memberId)
    {
        return Connection.Query<AccessChecked>("GetAccessesByMemberId", new { MemberId = memberId },
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<AccessChecked> GetAccessCheckedsByRole(int id)
    {
        return Connection.Query<AccessChecked>("GetAccessCheckedsByRole", new { RoleId = id },
            commandType: CommandType.StoredProcedure);
    }
    
    public IEnumerable<Access> GetAccessesByMember(string id)
    {
        return Connection.Query<Access>("GetAccessesByMember", new { id }, commandType: CommandType.StoredProcedure);
    }
}