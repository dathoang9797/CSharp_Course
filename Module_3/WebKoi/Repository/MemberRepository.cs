using WebAppAuthentication.Model;
using WebKoi.Model;

namespace WebKoi.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(KoiContext context) : base(context)
    {
    }

    public List<Member> GetMember()
    {
        return Context.Member.ToList();
    }

    public int Add(Member obj)
    {
        Context.Member.Add(obj);
        return Context.SaveChanges();
    }
}