using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebAppFruitable.Model;
using WebAppFruitable.Repository;

namespace WebAppFruitable.Repository;

public class RoleRepository : BaseRepository
{
    public RoleRepository(FruitableContext context) : base(context)
    {
    }

    public List<RoleChecked> GetRolesByMember(string memberId)
    {
        return Context.Database.SqlQuery<RoleChecked>($"EXEC GetRolesByMember @Id ={memberId}").ToList();
    }
}