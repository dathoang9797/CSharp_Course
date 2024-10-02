using WebKoi.Model;
using WebKoi.Services;

namespace WebKoi.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(KoiContext context) : base(context)
    {
    }

    public List<Member> GetMembers()
    {
        return Context.Member.ToList();
    }

    public int Add(Register obj)
    {
        Context.Member.Add(new Member()
        {
            MemberId = Helper.RandomString(32),
            Email = obj.Email,
            GivenName = obj.GiventName,
            Name = obj.Name,
            Surname = obj.Surname,
            Password = obj.Password != null ? Helper.Hash(obj.Password) : null
        });

        return Context.SaveChanges();
    }

    public Member? GetMember(LoginModel obj)
    {
        return Context.Member.SingleOrDefault(p =>
            obj.Pwd != null && p.Email == obj.Eml &&
            p.Password == Helper.Hash(obj.Pwd)
        );
    }

    public int Add(Member obj)
    {
        Context.Member.Add(obj);
        return Context.SaveChanges();
    }
}