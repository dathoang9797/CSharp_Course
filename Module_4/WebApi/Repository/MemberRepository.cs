using System.Data;
using Dapper;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(IDbConnection connection) : base(connection)
    {
    }

    static byte[] Salt(string Email, string Password)
    {
        return Helper.HashPassword(Email + "^%$^%$" + Password);
    }

    public IEnumerable<Member> GetMembers()
    {
        return Connection.Query<Member>("SELECT MemberId, Givenname, Surname, Email,CreatedDate, UpdatedDate,LoginDate  FROM Member");
    }

    public int Add(Member obj)
    {
        obj.MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty);
        var sql =
            "INSERT INTO Member (MemberId,GivenName, Surname,Email, Password) VALUES (@MemberId, @GivenName, @Surname, @Email, @Password)";
        return Connection.Execute(sql,
            new
            {
                obj.MemberId, obj.GivenName, obj.SurName, obj.Email,
                Password = Salt(obj.Email, obj.Password),
            });
    }

    public Member? GetMember(string id)
    {
        var sql =
            "SELECT MemberId, GivenName, Surname, Email, CreatedDate, UpdatedDate, LoginDate FROM Member WHERE MemberId = @Id";
        return Connection.QueryFirstOrDefault<Member>(sql, new { id });
    }

    public Member? Login(LoginModel obj)
    {
        var sql =
            "SELECT MemberId, GivenName, Surname, Email, CreatedDate, UpdatedDate, LoginDate FROM Member WHERE Email = @Email  AND Password = @Password";
        var rsp = Connection.QueryFirstOrDefault<Member>(sql,
            new { obj.Email, Password = Salt(obj.Email, obj.Password) });
        return rsp;
    }
}