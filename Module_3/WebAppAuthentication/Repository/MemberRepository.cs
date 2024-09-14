using Microsoft.AspNetCore.Identity;
using WebAppAuthentication.Model;

namespace WebAppAuthentication.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(StoreContext context) : base(context)
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