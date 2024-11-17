using WebAppAuthentication.Model;
using WebAppProduct.Models;
using WebAppProduct.Repository;

namespace WebAppAuthentication.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(ProjectContext context) : base(context)
    {
    }

    public int Add(Member obj)
    {
        if (!Context.Members.Any(p => p.MemberId == obj.MemberId))
        {
            Context.Members.Add(obj);
            return Context.SaveChanges();
        }

        return -1;
    }
}