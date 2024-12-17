using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;

namespace WebAppFruitable.Repository;

public class MemberInRoleRepository : BaseRepository
{
    public MemberInRoleRepository(FruitableContext context) : base(context)
    {
    }

    public async Task<int> AddAsync(MemberInRole obj)
    {
        var memberIdParam = new SqlParameter("@MemberId", obj.MemberId);
        var roleIdParam = new SqlParameter("@RoleId", obj.RoleId);
        return await Context.Database.ExecuteSqlRawAsync("EXEC SaveMemberInRole @MemberId, @RoleId", memberIdParam,
            roleIdParam);
    }
}