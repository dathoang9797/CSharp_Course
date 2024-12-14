using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;

namespace WebAppFruitable.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(FruitableContext context) : base(context)
    {
    }

    public int Add(MemberEntity obj)
    {
        Context.Member.Add(obj);
        return Context.SaveChanges();
    }
    
    public async Task<MemberEntity?> Login(MemberEntity obj)
    {

        var member = await Context.Member.FirstOrDefaultAsync(m => m.Email == obj.Email && m.Password == obj.Password);
        return member;
    }
}