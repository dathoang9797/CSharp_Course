using WebAppStore.Model;

namespace WebAppStore.Repository;

public class MemberRepository(StoreContext context)
{
    private StoreContext Context { get; set; } = context;

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