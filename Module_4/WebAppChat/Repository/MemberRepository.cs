using System.Collections.Generic;
using System.Data;
using Dapper;
using WebAppChat.Model;
using WebAppChat.Services;

namespace WebAppChat.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(IDbConnection connection) : base(connection)
    {
    }

    public Member? Login(Login obj)
    {
        // const string sql = "SELECT * FROM Member WHERE Email = @Email AND Password = @Password";
        const string sql = "LoginMember";
        var email = obj.Eml;
        var hashPassword = Helper.HashString(obj.Pwd);
        var objQuery = new
        {
            Email = email,
            Password = hashPassword
        };
        return Connection.QueryFirstOrDefault<Member>(sql, objQuery, commandType: CommandType.StoredProcedure);
    }

    public int? Logout(string? id)
    {
        const string sql = "UPDATE Member SET IsOnline = 0 WHERE MemberId = @Id";
        return Connection.Execute(sql, new { Id = id });
    }

    public int Register(Member obj)
    {
        var sql =
            "INSERT INTO Member (MemberId, GivenName, Surname, Email, Password, Phone, Role) " +
            "VALUES (@MemberId, @GivenName, @Surname, @Email, @Password, @Phone, @Role)";
        return Connection.Execute(sql, obj);
    }

    public IEnumerable<Member> GetEmployees()
    {
        return Connection.Query<Member>("SELECT * FROM Member WHERE Role = 'Employee'");
    }

    public IEnumerable<Member> GetMembers()
    {
        return Connection.Query<Member>("SELECT * FROM Member WHERE Role = 'Member'");
    }
}