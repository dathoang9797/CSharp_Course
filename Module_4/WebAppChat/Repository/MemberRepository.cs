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
        return Connection.QueryFirstOrDefault<Member>(
            "SELECT * FROM Member WHERE Email= @Email AND Password = @Password",
            new
            {
                Email = obj.Eml,
                Password = Helper.HashString(obj.Pwd)
            });
    }

    public IEnumerable<Member> GetEmployees()
    {
        return Connection.Query<Member>("SELECT * FROM Member WHERE Role = Employee");
    }
}